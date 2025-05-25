using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.proceso
{
    [Table("cartilla", Schema = "proceso")]
    public class Cartilla : EntityBase
    { 
        public int cartilla_id { get; set; }
        public int local_comercial_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int cantidad_sello { get; set; }
        public int cantidad_promocion { get; set; }
        public string estado { get; set; } 

    }
}
