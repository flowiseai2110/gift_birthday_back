using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.proceso
{ 
    public class CPromocion : EntityBase
    {

        //public int i_promocion_id { get; set; }
        //public int i_local_comercial_id { get; set; }
        //public string v_titulo { get; set; }
        //public string v_descripcion { get; set; }
        //public string v_estado { get; set; } 

        public int promocion_id { get; set; }
        public int local_comercial_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
  

    }
}
