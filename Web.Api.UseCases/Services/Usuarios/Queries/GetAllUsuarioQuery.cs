using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence;

namespace Web.Api.UseCases.Services.Usuarios.Queries
{
    public class GetAllUsuarioQuery : IRequest<IEnumerable<UsuarioDto>>
    { 
        public int local_comercial_id { get; set; }
    }
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioQuery, IEnumerable<UsuarioDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllUsuarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(GetAllUsuarioQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Usuario.GetUsuarioxLocalComercial(request.local_comercial_id);

            return result.ToList();
        }
    }
}
