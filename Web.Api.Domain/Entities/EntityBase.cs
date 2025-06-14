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
        public string? usuario_registro { get; set; } = string.Empty;
        public DateTime? fecha_registro { get; set; } = DateTime.UtcNow;
        public string? usuario_modificacion { get; set; } = string.Empty;
        public DateTime? fecha_modificacion { get; set; } = null;
    }
}
