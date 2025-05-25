using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities.config
{ 
    public class Usuario : Persona
    { 
        public int usuarioId { get; set; }
        public int localComercialId { get; set; }
          
    }
}
