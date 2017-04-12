using Automation.ConsoleApp.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;

namespace Preparation.ConsoleApp.Services
{
    public class PreparationService : IPreparationService
    {
        private readonly Automation.ConsoleApp.Options _options;
        private readonly IAutomationService _service;
        private readonly ITemplateService _template;

        public PreparationService(IAutomationService service, ITemplateService template, IOptions<Automation.ConsoleApp.Options> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _service = service;
            _template = template;
        }
        public void Run()
        {
            var template = _template.GetTemplate();
            addNuGetFeeds(template);
            addFunctions(template);
            _service.Run();
        }

        private void addFunctions(IDictionary<string, dynamic> template)
        {
            var packages = template["Packages"] as IDictionary<string, dynamic>;
            foreach (var package in packages ?? new Dictionary<string, dynamic>())
            {
                _service.Pipeline.Add((new Automation.Functions.CodeGeneration.AddNugetReference.Process().Function, new
                {
                    csproj = Path.Combine(_options.SolutionDirectory, "Automation.ConsoleApp/Automation.ConsoleApp.csproj"),
                    package = package.Key,
                    version = package.Value as string
                }));
                _service.Pipeline.Add((new Automation.Functions.FileFindAndReplace.Process().Function, new
                {
                    path = _options.OutputFilePath,
                    oldText = "/*{{processes}}*/",
                    newText = $"new {package.Key}.Process().Function,/*{{processes}}*/"
                }));
            }
        }

        private void addNuGetFeeds(IDictionary<string, dynamic> template)
        {
            var feeds = template["Feeds"] as IEnumerable<string>;
            foreach (var feed in feeds ?? new string[] { })
            {
                _service.Pipeline.Add((new Automation.Functions.CodeGeneration.AddNugetFeed.Process().Function, new
                {
                    path = _options.SolutionDirectory,
                    value = feed
                }));
            }
        }
    }
}
