using Microsoft.Extensions.DependencyInjection;

namespace dotnet_make.Services
{
    public static class AddApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
            => services;
    }
}
