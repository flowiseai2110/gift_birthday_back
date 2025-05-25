using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence;
using Web.Api.UseCases.Services.Usuarios.Queries;

namespace Web.Api.UseCases.Services.Promociones.Queries
{
    public class GetAllPromocionQuery : IRequest<IEnumerable<CPromocion>>
    {
        public int local_comercial_id { get; set; }
    }
    public class GetAllPromocionHandler : IRequestHandler<GetAllPromocionQuery, IEnumerable<CPromocion>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPromocionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CPromocion>> Handle(GetAllPromocionQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Promocion.GetAllAsync(new CPromocion() { local_comercial_id = request.local_comercial_id});

            return result.ToList();
        }
    }
}
