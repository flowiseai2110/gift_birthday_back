using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;

namespace Web.Api.UseCases.Services.Promociones.Command
{
    public record CreatePromocionCommand : IRequest<int>
    {
        public int promocion_id { get; set; }
        public int local_comercial_id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string usuario_registro { get; set; }

    }
}
