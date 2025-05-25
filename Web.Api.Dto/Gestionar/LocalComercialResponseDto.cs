using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Gestionar
{
    public class LocalComercialResponseDto
    {
        public int local_comercial_id { get; set; }
        public int empresa_id { get; set; }
        public string nombre_comercial { get; set; }
        public string direccion { get; set; }
        public string telefono_principal { get; set; }
        public string celular_principal { get; set; }
        public TimeSpan hora_inicio { get; set; }
        public TimeSpan hora_fin { get; set; }
        public string tipo_horario { get; set; }
        public string usuario_registro { get; set; }
        public string NombreEmpresa { get; set; }
    }
}
