using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Api.UseCases.Services.Plugins
{
    public interface IPluginService
    {
        TPlugin GetInstance<TPlugin>(string systemName) where TPlugin : class, IPlugin;
         
    }
}
