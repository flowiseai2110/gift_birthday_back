using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Infraestructure.EventBus.Options
{
    /*
     Esta clase vincula una seccion con una clase
     */
    public class RabbitMqOptions 
    {
        public string HostName { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
