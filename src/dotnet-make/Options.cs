using CommandLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_make
{
    public class Options
    {
        [Option('t', "template", Required = true,
            HelpText = "Path to template file to process")]
        public string TemplateFilePath { get; set; }

        [Option('o', "output", Required = true,
            HelpText = "Path to place files produced")]
        public string OutputFilePath { get; set; }
    }
}
