using AVA.PacxPlugins.AddSolutionComponent.Strategy.Interface;
using AVA.PacxPlugins.AddSolutionComponent.Strategy.Strategies;
using Greg.Xrm.Command.Services.Connection;
using Greg.Xrm.Command.Services.Output;

namespace AVA.PacxPlugins.AddSolutionComponent.Strategy.Factory
{
    public class AddComponentCommandStrategyFactory : IAddComponentStrategyFactory
    {
        private readonly IOutput output;
        private readonly IOrganizationServiceRepository organizationServiceRepository;
        private readonly AddComponentCommand command;
        private readonly CancellationToken cancellationToken;
        public AddComponentCommandStrategyFactory(IOrganizationServiceRepository organizationServiceRepository, AddComponentCommand command, CancellationToken cancellationToken, IOutput output)
        {
            this.output = output;
            this.organizationServiceRepository = organizationServiceRepository;
            this.command = command;
            this.cancellationToken = cancellationToken;
        }

        public IAddComponentStrategy GetStrategy(string componentType)
        {

            switch (componentType)
            {
                case nameof(ComponentType.WebResource):
                    return new AddComponentWebResourceStrategy(output, organizationServiceRepository, command, cancellationToken);
                default:
                    return null;
            }      
        }
    }
}
