using System;
using System.Collections.Generic;

namespace Automation.ConsoleApp.Services
{
    public interface IAutomationService
    {
        ICollection<(Func<dynamic, dynamic, dynamic> Function, dynamic Argument)> Pipeline { get; set; }
        void Run();
    }
}