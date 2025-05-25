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
using Web.Api.UseCases.Services.Cartillas.Command;
using Web.Api.UseCases.Services.Empresas.Command;

namespace Web.Api.UseCases.Services.LocalesComerciales.Command
{
    public sealed class CreateLocalComercialHandler : IRequestHandler<CreateLocalComercialCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateLocalComercialHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLocalComercialCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<LocalComercial>(request);
            obj.activo = true;
            obj.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.LocalComercial.CreateAsync(obj);

            return result;
        }
        //public LocalComercial MapperLocalComercial(CreateLocalComercialCommand request)
        //{
        //    var mapConfig = new MapperConfiguration(
        //            cfg => cfg.CreateMap<CreateLocalComercialCommand, LocalComercial>()
        //            .ForMember(dest => dest.i_local_comercial_id, opt => opt.MapFrom(src => src.local_comercial_id))
        //            .ForMember(dest => dest.i_empresa_id, opt => opt.MapFrom(src => src.empresa_id))
        //            .ForMember(dest => dest.v_nombre_comercial, opt => opt.MapFrom(src => src.nombre_comercial))
        //            .ForMember(dest => dest.v_direccion, opt => opt.MapFrom(src => src.direccion))
        //            .ForMember(dest => dest.v_telefono_principal, opt => opt.MapFrom(src => src.telefono_principal))
        //            .ForMember(dest => dest.v_celular_principal, opt => opt.MapFrom(src => src.celular_principal))
        //            .ForMember(dest => dest.t_hora_inicio, opt => opt.MapFrom(src => src.hora_inicio))
        //            .ForMember(dest => dest.t_hora_fin, opt => opt.MapFrom(src => src.hora_fin))
        //            .ForMember(dest => dest.v_tipo_horario, opt => opt.MapFrom(src => src.tipo_horario))
        //        );

        //    var mapper = mapConfig.CreateMapper();

        //    return mapper.Map<LocalComercial>(request);
        //}
    }
}
