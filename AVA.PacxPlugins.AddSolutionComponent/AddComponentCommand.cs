using System.ComponentModel.DataAnnotations;
using Greg.Xrm.Command;
namespace AVA.PacxPlugins.AddSolutionComponent
{
    [Command("addsolutioncomponent", HelpText = "Add a solution component to an unmanaged solution.")]   
    public class AddComponentCommand
    {
        [Option("componentType", "ct", HelpText = "The type of the component to add")]
        [Required]
        public string ComponentType { get; set; }
        [Option("componentName", "n", HelpText = "The name of the component to add")]
        [Required]
        public string Name { get; set; }

        [Option("solutionName", "sln", HelpText = "The name of the solution")]
        [Required]
        public string SolutionName { get; set; }
    }
}
