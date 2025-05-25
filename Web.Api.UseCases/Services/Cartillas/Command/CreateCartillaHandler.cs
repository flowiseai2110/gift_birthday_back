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
using Web.Api.UseCases.Services.Empresas.Command;
using Web.Api.UseCases.Services.Promociones.Command;

namespace Web.Api.UseCases.Services.Cartillas.Command
{
    public class CreateCartillaHandler : IRequestHandler<CreateCartillaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCartillaHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCartillaCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Cartilla>(request);
            obj.activo = true;
            obj.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.Cartilla.CreateAsync(obj);

            return result;
        }
        //public Cartilla MapperCartilla(CreateCartillaCommand request)
        //{
        //    var mapConfig = new MapperConfiguration(
        //            cfg => cfg.CreateMap<CreateCartillaCommand, Cartilla>()
        //            .ForMember(dest => dest.i_cartilla_id, opt => opt.MapFrom(src => src.cartilla_id))
        //            .ForMember(dest => dest.i_local_comercial_id, opt => opt.MapFrom(src => src.local_comercial_id))
        //            .ForMember(dest => dest.v_titulo, opt => opt.MapFrom(src => src.titulo))
        //            .ForMember(dest => dest.v_descripcion, opt => opt.MapFrom(src => src.descripcion))
        //            .ForMember(dest => dest.i_cantidad_sello, opt => opt.MapFrom(src => src.cantidad_sello))
        //            .ForMember(dest => dest.i_cantidad_promocion, opt => opt.MapFrom(src => src.cantidad_promocion))
        //            .ForMember(dest => dest.v_estado, opt => opt.MapFrom(src => src.estado))
        //            .ForMember(dest => dest.usuario_registro, opt => opt.MapFrom(src => src.usuario_registro))
        //        );

        //    var mapper = mapConfig.CreateMapper();

        //    return mapper.Map<Cartilla>(request);
        //}
    }
}
