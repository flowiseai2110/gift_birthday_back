using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    //[Table("evento", Schema = "public")]
    public class EventoBE: EntityBase
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty; 
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public TimeSpan hora_inicio { get; set; } 
        public TimeSpan hora_fin { get; set; }  
        
    }
}
