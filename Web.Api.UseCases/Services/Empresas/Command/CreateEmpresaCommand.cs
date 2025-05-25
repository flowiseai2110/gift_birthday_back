using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar; 

namespace Web.Api.UseCases.Services.Empresas.Command
{
    public record CreateEmpresaCommand : IRequest<EmpresaDto>
    {
        public int empresa_id { get; set; }
        public string razon_social { get; set; }
        public string ruc { get; set; }
        public string direccion { get; set; }
        public string telefono_principal { get; set; }
        public string celular_principal { get; set; }
        public string usuario_registro { get; set; }
    }
}
