using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence;
using Web.Api.UseCases.Services.Empresas.Queries;

namespace Web.Api.UseCases.Services.LocalesComerciales.Queries
{
    public class GetAllLocalComercialQuery : IRequest<IEnumerable<LocalComercial>>
    {
        public int i_empresa_id { get; set; }
       
    }
    public class GetAllLocalComercialHandler : IRequestHandler<GetAllLocalComercialQuery, IEnumerable<LocalComercial>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLocalComercialHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocalComercial>> Handle(GetAllLocalComercialQuery request, CancellationToken cancellationToken)
        { 
            var result = await _unitOfWork.LocalComercial.GetAllAsync(new LocalComercial());
             
            return result;
        }
    }
}
