using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    public class EntityBase
    {
        public bool activo { get; set; }
        public string usuarioRegistro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string? usuarioModificacion { get; set; }
        public DateTime? fechaModificacion { get; set; }
    }
}
