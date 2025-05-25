using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;

namespace Web.Api.UseCases.Services.LocalesComerciales.Command
{
    public record CreateLocalComercialCommand : IRequest<int>
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
    }
}
