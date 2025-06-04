using AVA.PacxPlugins.AddSolutionComponent.Strategy.Interface;
using Greg.Xrm.Command.Services.Connection;
using Greg.Xrm.Command.Services.Output;
using Greg.Xrm.Command;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace AVA.PacxPlugins.AddSolutionComponent.Strategy.Strategies
{
    public class AddComponentWebResourceStrategy : IAddComponentStrategy
    {
        private readonly IOutput output;
        private readonly IOrganizationServiceRepository organizationServiceRepository;
        private readonly AddComponentCommand command;
        private readonly CancellationToken cancellationToken;

        public AddComponentWebResourceStrategy(
            IOutput output,
            IOrganizationServiceRepository organizationServiceRepository,
            AddComponentCommand command,
            CancellationToken cancellationToken)
        {
            this.output = output;
            this.organizationServiceRepository = organizationServiceRepository;
            this.command = command;
            this.cancellationToken = cancellationToken;
        }
        public async Task<CommandResult> Apply()
        {

            this.output.Write($"Connecting to the current dataverse environment...");

            var name = command.Name;
            var solutionName = command.SolutionName;

            var crm = await this.organizationServiceRepository.GetCurrentConnectionAsync();

            var querySln = new QueryExpression("solution");
            querySln.ColumnSet = new ColumnSet("solutionid", "friendlyname", "uniquename");
            querySln.Criteria.AddCondition("friendlyname", ConditionOperator.Equal, solutionName);

            var solution = await crm.RetrieveMultipleAsync(querySln, cancellationToken);

            if (!solution.Entities.Any())
            {
                return CommandResult.Fail($"Solution '{solutionName}' not found.");
            }


            var queryWr = new QueryExpression("webresource");
            queryWr.Criteria.AddCondition("name", ConditionOperator.Equal, name);

            var webResource = await crm.RetrieveMultipleAsync(queryWr, cancellationToken);

            if (!webResource.Entities.Any())
            {
                return CommandResult.Fail($"Web resource '{name}' not found.");
            }


            var webResourceEntity = webResource.Entities.First();
            var solutionUniqueName = solution.Entities.First().GetAttributeValue<string>("uniquename");


            output.Write("Adding web resource to solution...");
            try
            {
                var request = new AddSolutionComponentRequest
                {
                    ComponentId = webResourceEntity.Id,
                    ComponentType = (int)ComponentType.WebResource,
                    SolutionUniqueName = solutionUniqueName
                };

                var response = await crm.ExecuteAsync(request);
                this.output.WriteLine("Done", ConsoleColor.Green);

                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Fail($"Error adding web resource to solution: {ex.Message}");
            }
        }
    }
}
