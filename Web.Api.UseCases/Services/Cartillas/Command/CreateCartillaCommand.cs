using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;

namespace Web.Api.UseCases.Services.Cartillas.Command
{
    public record CreateCartillaCommand : IRequest<int>
    {
        public int cartilla_id { get; set; }
        public int local_comercial_id { get; set; }
        public string codigo { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int cantidad_sello { get; set; }
        public int cantidad_promocion { get; set; }
        public string estado { get; set; }
        public string usuario_registro { get; set; }
    }
}
