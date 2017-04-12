using Microsoft.Extensions.DependencyInjection;
/*{{usings}}*/

namespace Automation.ConsoleApp.Services
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services
                /*{{services}}*/
                .AddSingleton<IAutomationService, AutomationService>()
                .AddSingleton<ITemplateService, TemplateService>();
    }
}
