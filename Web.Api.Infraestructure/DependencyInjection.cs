using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Web.Api.Infraestructure.EventBus;
using Web.Api.Infraestructure.EventBus.Options;
using Web.Api.Interface.Infraestructure;

namespace Web.Api.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services ) {
            services.ConfigureOptions<RabbitMqOptionsSetup>();
            services.AddScoped<IEventBus,EventBusRabbitMQ>();
            services.AddMassTransit(x => {
                x.UsingRabbitMq( (context,cfg) => { 
                    RabbitMqOptions? opt = services.BuildServiceProvider().GetRequiredService<IOptions<RabbitMqOptions>>().Value;

                    cfg.Host( opt.HostName, opt.VirtualHost, h => {
                        h.Username(opt.UserName);
                        h.Password(opt.Password);
                    });

                    cfg.ConfigureEndpoints(context);

                });
                
            });

            return services;
        }
    }
}
