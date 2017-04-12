using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Automation.ConsoleApp.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly Options _options;

        public TemplateService(IOptions<Options> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public IDictionary<string, dynamic> GetTemplate()
        {
            var json = File.ReadAllText(_options.TemplateFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(json);
        }
    }
}
