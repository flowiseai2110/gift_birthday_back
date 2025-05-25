using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.proceso
{ 
    public class CartillaPromocion : EntityBase
    { 
        public int cartilla_promocion_id { get; set; }
        public int cartilla_id { get; set; }
        public int promocion_id { get; set; }
        public int local_comercial_id { get; set; }
        public DateTime fecha_promocion_inicio { get; set; }
        public DateTime fecha_promocion_fin { get; set; }
        public string estado { get; set; }

    }
}
