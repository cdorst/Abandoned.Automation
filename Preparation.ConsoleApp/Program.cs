using Automation.ConsoleApp.Services;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Preparation.ConsoleApp.Services;
using System;

namespace Automation.ConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
            => Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options => Run(options));

        public static void Run(Options options)
        {
            var serviceProvider = ConfigureServices(options);
            AddLogging(serviceProvider);
            var service = serviceProvider.GetService<IPreparationService>();
            service.Run();
        }

        private static IServiceProvider ConfigureServices(Options options)
            => new ServiceCollection()
                .AddLogging()
                .AddOptions()
                .Configure<Options>(o =>
                {
                    o.OutputFilePath = options.OutputFilePath;
                    o.TemplateFilePath = options.TemplateFilePath;
                })
                .AddApplicationServices()
                .AddSingleton<IPreparationService, PreparationService>()
                .BuildServiceProvider();

        private static void AddLogging(IServiceProvider serviceProvider)
            => serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);
    }
}