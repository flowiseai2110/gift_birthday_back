 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Api.Infraestructure;

namespace Web.Api.UseCases.Services.Plugins
{
    public class PluginService : IPluginService
    {
        public PluginService()
        {

        } 
        public TPlugin GetInstance<TPlugin>(string systemName) where TPlugin : class, IPlugin
        {
            //try to resolve plugin as unregistered service

            //var pluginType = pluginDescriptor.ReferencedAssembly.GetTypes().FirstOrDefault(type =>
            //                       typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface && type.IsClass && !type.IsAbstract);

            //$"Pro.CB.Core.Aplicacion.Services.Secciones.DatosGenerales.Base.DatosGeneralesSeccion"
            Type pluginType = Type.GetType(systemName);

            var instance = EngineContext.Current.ResolveUnregistered(pluginType);

            //try to get typed instance
            var typedInstance = instance as TPlugin;

            return typedInstance;
        }

    }
}
