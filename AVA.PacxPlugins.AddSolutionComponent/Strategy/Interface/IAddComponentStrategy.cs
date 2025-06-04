using Greg.Xrm.Command;

namespace AVA.PacxPlugins.AddSolutionComponent.Strategy.Interface
{
    public interface IAddComponentStrategy
    {
        Task<CommandResult> Apply();
    }
}
