using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Dto.Gestionar;
using Web.Api.Interface.Persistence;
using Web.Api.UseCases.Services.Usuarios.Command;

namespace Web.Api.UseCases.Services.Promociones.Command
{
    public class CreatePromocionHandler : IRequestHandler<CreatePromocionCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePromocionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePromocionCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<CPromocion>(request);
            obj.activo = true;
            obj.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.Promocion.CreateAsync(obj);

            return result;
        }
        //public CPromocion MapperPromocion(CreatePromocionCommand request)
        //{
        //    var mapConfig = new MapperConfiguration(
        //            cfg => cfg.CreateMap<CreatePromocionCommand, CPromocion>()
        //            .ForMember(dest => dest.i_promocion_id, opt => opt.MapFrom(src => src.promocion_id))
        //            .ForMember(dest => dest.i_local_comercial_id, opt => opt.MapFrom(src => src.local_comercial_id))
        //            .ForMember(dest => dest.v_titulo, opt => opt.MapFrom(src => src.titulo))
        //            .ForMember(dest => dest.v_descripcion, opt => opt.MapFrom(src => src.descripcion))
        //            .ForMember(dest => dest.v_estado, opt => opt.MapFrom(src => src.estado))
        //             .ForMember(dest => dest.usuario_registro, opt => opt.MapFrom(src => src.usuario_registro))
        //        );

        //    var mapper = mapConfig.CreateMapper();

        //    return mapper.Map<CPromocion>(request);
        //}
    }
}
