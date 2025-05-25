using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Dto.Gestionar
{
    public class EmpresaDto
    {
        public int empresa_id { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string telefono_principal { get; set; }
        public string celular_principal { get; set; }
        public DateTime fecha_registro { get; set; }
        public string usuario_registro { get; set; }

    }
}
