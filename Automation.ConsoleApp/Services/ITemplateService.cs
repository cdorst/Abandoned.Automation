using System.Collections.Generic;

namespace Automation.ConsoleApp.Services
{
    public interface ITemplateService
    {
        IDictionary<string, dynamic> GetTemplate();
    }
}