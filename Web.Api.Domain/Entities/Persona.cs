using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Domain.Entities
{
    public class Persona:EntityBase
    {
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string celular { get; set; }
        public string correo_electronico { get; set; }
    }
}
