using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    public class Gift
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public int categoria_id { get; set; }
        public string imagen_url { get; set; } = string.Empty;
        public string precio { get; set; }
        
        // Additional properties can be added as needed
    }
}
