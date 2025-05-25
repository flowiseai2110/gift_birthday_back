using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Gestionar
{
    public class CartillaDto
    { 
        public int cartilla_id { get; set; }
        public int local_comercial_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int cantidad_sello { get; set; }
        public int cantidad_promocion { get; set; }
        public string estado { get; set; }
        public string usuario_registro { get; set; }
    }
}
