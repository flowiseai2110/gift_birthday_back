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
using Web.Api.UseCases.Services.Clientes.Queries;

namespace Web.Api.UseCases.Services.Clientes.Queries
{
    public class GetAllClienteQuery : IRequest<IEnumerable<Cliente>>
    {
        public int local_comercial_id { get; set; }
    }
    public class GetAllClienteHandler : IRequestHandler<GetAllClienteQuery, IEnumerable<Cliente>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllClienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Cliente>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Cliente.GetAllAsync(new Cliente() { local_comercial_id = request.local_comercial_id});

            return result.ToList();
        }
    }
}
