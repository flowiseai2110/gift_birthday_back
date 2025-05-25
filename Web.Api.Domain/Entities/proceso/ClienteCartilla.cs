using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.proceso
{ 
    public class ClienteCartilla : EntityBase
    { 
        public int cliente_cartilla_id { get; set; }
        public int cliente_id { get; set; }
        public int cartilla_promocion_id { get; set; }
        public int local_comercial_id { get; set; }
        public int numero_promocion { get; set; }
        public int numero_sello { get; set; }
        public string estado { get; set; }

    }
}
