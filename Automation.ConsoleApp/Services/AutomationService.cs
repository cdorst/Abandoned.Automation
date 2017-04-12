using System;
using System.Collections.Generic;
/*{{usings}}*/

namespace Automation.ConsoleApp.Services
{
    public class AutomationService : IAutomationService
    {
        private readonly ITemplateService _template;

        public AutomationService(
            /*{{dependencies}}*/
            ITemplateService templateService)
        {
            _template = templateService;

            Pipeline = new List<(Func<dynamic, dynamic, dynamic> Function, dynamic Argument)>
            {
                /*{{processes}}*/
            };
        }

        public ICollection<(Func<dynamic, dynamic, dynamic> Function, dynamic Argument)> Pipeline { get; set; }

        public void Run()
        {
            dynamic state = _template.GetTemplate();
            foreach (var process in Pipeline)
            {
                state = process.Function(state, process.Argument);
            }
        }
    }
}
