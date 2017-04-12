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

            Pipeline = new Func<dynamic, dynamic, dynamic>[]
            {
                (state, arg) => state,
                /*{{processes}}*/
            };
        }

        public ICollection<Func<dynamic, dynamic, dynamic>> Pipeline { get; set; }

        public void Run()
        {
            dynamic state = _template.GetTemplate();
            foreach (var process in Pipeline)
            {
                state = process(state, state);
            }
        }
    }
}
