using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.UseCases.Services.Plugins
{
    public partial interface IPluginManager<TPlugin> where TPlugin : class, IPlugin
    {
        TPlugin LoadPluginByName(string sectionName);
    }
}
