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
    public class GetLocalComercialxEmpresa2Query : IRequest<IEnumerable<LocalComercialResponseDto>>
    {
        public int i_empresa_id { get; set; }
       
    }
    public class GetLocalComercialxEmpresa2Handler : IRequestHandler<GetLocalComercialxEmpresa2Query, IEnumerable<LocalComercialResponseDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetLocalComercialxEmpresa2Handler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocalComercialResponseDto>> Handle(GetLocalComercialxEmpresa2Query request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Hora inicio Ef:" + DateTime.Now.Add(TimeSpan.FromMilliseconds(100)));
            var result = await _unitOfWork.LocalComercial.GetLocalxEmpresa(request.i_empresa_id);
            Console.WriteLine("Hora inicio Ef:" + DateTime.Now.Add(TimeSpan.FromMilliseconds(100)));
            return result ;
        }
    }
}
