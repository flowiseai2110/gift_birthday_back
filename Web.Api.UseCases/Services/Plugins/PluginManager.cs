
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Api.UseCases.Services.Plugins
{
    public partial class PluginManager<TPlugin> : IPluginManager<TPlugin> where TPlugin : class, IPlugin
    {

        private readonly IPluginService _pluginService;

        private readonly Dictionary<string, IList<TPlugin>> _plugins = new Dictionary<string, IList<TPlugin>>();

        public PluginManager(IPluginService pluginService)
        {
            _pluginService = pluginService;
        }
        public TPlugin LoadPluginByName(string systemName)
        {
            if (string.IsNullOrEmpty(systemName))
                return null;

            //try to get already loaded plugin
            var key = systemName;
            if (_plugins.ContainsKey(key))
                return _plugins[key].FirstOrDefault();

            //or get it from list of all loaded plugins or load it for the first time
            var pluginBySystemName = _plugins.TryGetValue(key, out var plugins)
                && plugins.FirstOrDefault() is TPlugin loadedPlugin
                ? loadedPlugin
                : _pluginService.GetInstance<TPlugin>(systemName);

            _plugins.Add(key, new List<TPlugin> { pluginBySystemName });

            return pluginBySystemName;
        }


    }
}
