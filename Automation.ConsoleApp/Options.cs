using CommandLine;

namespace Automation.ConsoleApp
{
    public class Options
    {
        [Option('t', "template", Required = true,
            HelpText = "Path to template file to process")]
        public string TemplateFilePath { get; set; }

        [Option('o', "output", Required = true,
            HelpText = "Path to place files produced")]
        public string OutputFilePath { get; set; }

        [Option('d', "directory", Required = false,
            HelpText = "Solution directory path")]
        public string SolutionDirectory { get; set; }
    }
}