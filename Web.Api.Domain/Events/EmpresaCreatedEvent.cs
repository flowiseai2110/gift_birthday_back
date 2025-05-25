using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Events
{
    public class EmpresaCreatedEvent
    {
        public string empresa_id { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
    }
}
