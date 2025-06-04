using AVA.PacxPlugins.AddSolutionComponent.Strategy.Factory;
using Greg.Xrm.Command.Services.Connection;
using Greg.Xrm.Command.Services.Output;
using Greg.Xrm.Command;
 
namespace AVA.PacxPlugins.AddSolutionComponent
{
    public class AddComponentCommandExecutor : ICommandExecutor<AddComponentCommand>
    {
        private readonly IOutput output;
        private readonly IOrganizationServiceRepository organizationServiceRepository;

        public AddComponentCommandExecutor(
            IOutput output,
            IOrganizationServiceRepository organizationServiceRepository)
        {
            this.output = output;
            this.organizationServiceRepository = organizationServiceRepository;
        }

        public async Task<CommandResult> ExecuteAsync(AddComponentCommand command, CancellationToken cancellationToken)
        {
            var addCommandStrategyFactory = new AddComponentCommandStrategyFactory(organizationServiceRepository, command, cancellationToken,output);
            var strategy = addCommandStrategyFactory.GetStrategy(command.ComponentType);

            if(strategy == null)
            {
                return CommandResult.Fail($"No strategy found for component type '{command.ComponentType}'.");
            }

            return await strategy.Apply();

        }
    }
}
