using System.Text.Json.Serialization;

namespace WEB.API.ECOMMERCE.Modules.Features
{
    public static class FeaturesExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services) { 
            services.AddControllers().AddJsonOptions(opt => { 
                var enumConverter = new JsonStringEnumConverter();
                opt.JsonSerializerOptions.Converters.Add(enumConverter);  
            });
            return services;
        }
    }
}
