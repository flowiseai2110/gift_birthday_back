using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Gestionar
{
    public class UsuarioDto
    {
        public int usuario_id { get; set; }
        public int local_comercial_id { get; set; }
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string celular { get; set; }
        public string correo_electronico { get; set; }
        public string v_usuario_registro { get; set; }
    }

    public partial class UsuarioSupabaseDto{
        public int i_id { get; set; }
        public string? v_dni { get; set; }
        public string? v_nombre { get; set; }
        public string? v_apellido_paterno { get; set; }
        public string? v_apellido_materno { get; set; }

    }
}
