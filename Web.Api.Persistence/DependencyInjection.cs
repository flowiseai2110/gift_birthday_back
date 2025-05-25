using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Web.Api.Interface;
using Web.Api.Persistence.Context;
using Web.Api.Persistence.Context.Promocion;
using Web.Api.Persistence.Repositories;
using Web.Api.Persistence.Repositories.Ecommerce;
using Web.Api.Persistence.Repositories.Promociones;
using Web.Data.Core;

namespace Web.Api.Persistence
{
    
    public static class DependencyInjection  
    {
         
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddSingleton<ApplicationContext>();
            services.AddSingleton<DapperContext>();
            services.AddSingleton<PromocionContext>();
            services.AddSingleton<DapperPromocionContext>();
            services.AddSingleton<SupabaseContext>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();


            //services.AddScoped<IProductoRepository, ProductoRepository>();
            //services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            //services.AddScoped<ILocalComercialRepository, LocalComercialRepository>();
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            //services.AddScoped<ICPromocionRepository, CPromocionRepository>();
            //services.AddScoped<IClienteRepository, ClienteRepository>();
            //services.AddScoped<ICartillaRepository, CartillaRepository>();

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });

            return services;
        }
    }
}
