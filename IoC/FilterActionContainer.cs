using IoC.ActionFilters;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class FilterActionContainer
    {
        public static void FilterActionServices(IServiceCollection services)
        {
            services.AddScoped<ValidationFilter>();
        }
    }
}