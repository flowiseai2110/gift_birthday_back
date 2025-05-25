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
    public class GetLocalComercialxEmpresaQuery : IRequest<IEnumerable<LocalComercialResponseDto>>
    {
        public int i_empresa_id { get; set; }
       
    }
    public class GetLocalComercialxEmpresaHandler : IRequestHandler<GetLocalComercialxEmpresaQuery, IEnumerable<LocalComercialResponseDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLocalComercialxEmpresaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocalComercialResponseDto>> Handle(GetLocalComercialxEmpresaQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hora inicio dapper:" + DateTime.Now.Add(TimeSpan.FromMilliseconds(100)));
            var result = await _unitOfWork.LocalComercial.GetLocalxEmpresaxQuery(request.i_empresa_id);
            Console.WriteLine("Hora fin dapper:" + DateTime.Now.Add(TimeSpan.FromMilliseconds(100)));
            return result ;
        }
    }
}
