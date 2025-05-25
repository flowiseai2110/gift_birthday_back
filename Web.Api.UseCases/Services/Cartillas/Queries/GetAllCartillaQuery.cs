using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Interface.Persistence;
using Web.Api.UseCases.Services.Cartillas.Queries;

namespace Web.Api.UseCases.Services.Cartillas.Queries
{
    public class GetAllCartillaQuery : IRequest<IEnumerable<Cartilla>>
    {
        public int local_comercial_id { get; set; }
    }
    public class GetAllCartillaHandler : IRequestHandler<GetAllCartillaQuery, IEnumerable<Cartilla>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCartillaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cartilla>> Handle(GetAllCartillaQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Cartilla.GetAllAsync(new Cartilla() { local_comercial_id = request.local_comercial_id });

            return result.ToList();
        }
    }
}
