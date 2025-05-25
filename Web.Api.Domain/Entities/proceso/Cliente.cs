using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.proceso
{ 
    public class Cliente : Persona
    { 
        public int cliente_id { get; set; }
        public int local_comercial_id { get; set; }
        public string tipo_cliente { get; set; }
        
    }
}
