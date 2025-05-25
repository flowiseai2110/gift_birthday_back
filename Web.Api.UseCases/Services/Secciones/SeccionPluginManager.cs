
using System;
using System.Collections.Generic;
using System.Text;
using Web.Api.UseCases.Services.Plugins;


namespace Web.Api.UseCases.Services.Secciones
{
    public class SeccionPluginManager : PluginManager<ISeccion>, ISeccionPluginManager
    {
        private readonly IPluginService _pluginService;

        public SeccionPluginManager(IPluginService pluginService) : base(pluginService)
        {
            _pluginService = pluginService;
        }
    }
}
