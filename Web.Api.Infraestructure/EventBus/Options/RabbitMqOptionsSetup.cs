using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Web.Api.Infraestructure.EventBus.Options
{
    public class RabbitMqOptionsSetup : IConfigureOptions<RabbitMqOptions>
    {
        private const string configurationSectionName = "RabbitMqOptions";
        private readonly IConfiguration configuration;

        public RabbitMqOptionsSetup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(RabbitMqOptions options)
        {
            configuration.GetSection(configurationSectionName).Bind(options);
            //using Microsoft.Extensions.Configuration.Binder; esta libreria es necesario instalarlo para que reconosca el Bind
        }
    }
}
