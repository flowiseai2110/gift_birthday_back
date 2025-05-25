using Autofac;
using Microsoft.Extensions.Configuration;
using Web.Api.Persistence;
using Web.Api.UseCases;
using WEB.API.ECOMMERCE.Modules.Features;
using WEB.API.ECOMMERCE.Modules.Middleware;
 
using Web.Api.Infraestructure; 
using Autofac.Extensions.DependencyInjection;

using Web.Data.Core;
using Web.Api.Interface;
using LinqToDB.Common;
using Web.Api.Persistence.Context;
using Web.Api.UseCases.Services.Secciones; 
using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using Web.Api.UseCases.Services.Plugins; 
using Web.Api.Interface.UseCases.Servicios.Productos;
using Web.Api.UseCases.Services.Productos;

var builder = WebApplication.CreateBuilder(args);

var engine = EngineContext.Create();

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((builder) =>
    {
        string connectionString = "Server=192.168.18.6;Database=db_ecommerce_dev;uid=postgres;pwd=admin;";

        builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Web.Api.UseCases")))
               .Where(t => t.Name.EndsWith("Query", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
               .AsImplementedInterfaces();
        builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Web.Api.UseCases")))
                .Where(t => t.Name.EndsWith("Command", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();

        builder.RegisterType<DbAppContext>().Named<IDbContext>("context")
               .WithParameter("connstr", connectionString).InstancePerLifetimeScope();

        builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

        builder.RegisterType<PluginService>().As<IPluginService>().InstancePerLifetimeScope();
        builder.RegisterType<UnitOfWork>()
               .As<IUnitOfWork>()
               .WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"))
               .InstancePerLifetimeScope();

        builder.RegisterType<SeccionService>().As<ISeccionService>().InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(PluginManager<>)).As(typeof(IPluginManager<>)).InstancePerLifetimeScope();
        builder.RegisterType<SeccionPluginManager>().As<ISeccionPluginManager>().InstancePerLifetimeScope();
        //builder.RegisterType<EmpresaService>().As<IEmpresaService>().InstancePerLifetimeScope();
        builder.RegisterType<ProductoService>().As<IProductoService>().InstancePerLifetimeScope();

    });
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfraestructureServices();
builder.Services.AddFeature();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers().AddJsonOptions(option => {
    option.JsonSerializerOptions.PropertyNamingPolicy = null;
});


builder.Services.AddCors(opt =>
{

    var rutasHabilitas = new List<string>();
    rutasHabilitas.Add("https://localhost:4200");
    rutasHabilitas.Add("http://localhost:4200");
    rutasHabilitas.Add("https://localhost:4300");
    rutasHabilitas.Add("http://localhost:4300");
    //Configuration.GetSection("CORS").Bind(rutasHabilitas);
    opt.AddPolicy("Ecommerce", det =>
    {
        det.WithOrigins(rutasHabilitas.ToArray()).WithMethods(new string[] { "Get", "Post", "Put" }).AllowAnyHeader();
    });
});

var app = builder.Build();
var autofacContainer = app.Services.GetAutofacRoot();
EngineContext.Current.ConfigureRequestPipeline(app);
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseCors("Ecommerce");
app.UseAuthorization();

app.AddMiddleware();

app.MapControllers();

app.Run();
