namespace AVA.PacxPlugins.AddSolutionComponent.Strategy.Interface
{
    public interface IAddComponentStrategyFactory
    {
        IAddComponentStrategy GetStrategy(string componentType);
    }
}
