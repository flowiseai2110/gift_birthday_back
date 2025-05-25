using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;

namespace Web.Api.UseCases.Services.Clientes.Command
{
    public record CreateClienteCommand : IRequest<int>
    { 
        public int cliente_id { get; set; }
        public int local_comercial_id { get; set; }
        public string tipo_cliente { get; set; }
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nombre { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string celular { get; set; }
        public string correo_electronico { get; set; }
        public string usuario_registro { get; set; }
    }
}
