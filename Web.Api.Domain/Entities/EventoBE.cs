using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    public class EventoBE: EntityBase
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int categoria_id { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string hora_inicio { get; set; } = string.Empty;
        public string hora_fin { get; set; } = string.Empty;
        public int estado { get; set; } 
        
    }
}
