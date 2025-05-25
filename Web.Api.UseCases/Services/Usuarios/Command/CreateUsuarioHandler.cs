using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Interface.Persistence;
using Web.Api.UseCases.Services.LocalesComerciales.Command;

namespace Web.Api.UseCases.Services.Usuarios.Command
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUsuarioHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Usuario>(request);
            obj.activo = true;
            obj.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.Usuario.CreateAsync(obj);

            return result;
        }
        //public Usuario MapperUsuario(CreateUsuarioCommand request)
        //{
        //    var mapConfig = new MapperConfiguration(
        //            cfg => cfg.CreateMap<CreateUsuarioCommand, Usuario>()
        //            .ForMember(dest => dest.i_usuario_id, opt => opt.MapFrom(src => src.usuario_id))
        //            .ForMember(dest => dest.i_local_comercial_id, opt => opt.MapFrom(src => src.local_comercial_id))
        //            .ForMember(dest => dest.v_numero_documento, opt => opt.MapFrom(src => src.numero_documento))
        //            .ForMember(dest => dest.v_tipo_documento, opt => opt.MapFrom(src => src.tipo_documento))
        //            .ForMember(dest => dest.v_nombre, opt => opt.MapFrom(src => src.nombre))
        //            .ForMember(dest => dest.v_apellido_paterno, opt => opt.MapFrom(src => src.apellido_paterno))
        //            .ForMember(dest => dest.v_apellido_materno, opt => opt.MapFrom(src => src.apellido_materno))
        //            .ForMember(dest => dest.d_fecha_nacimiento, opt => opt.MapFrom(src => src.fecha_nacimiento))
        //            .ForMember(dest => dest.v_celular, opt => opt.MapFrom(src => src.celular))
        //            .ForMember(dest => dest.v_correo_electronico, opt => opt.MapFrom(src => src.correo_electronico))
        //            .ForMember(dest => dest.usuario_registro, opt => opt.MapFrom(src => src.usuario_registro))
        //        );

        //    var mapper = mapConfig.CreateMapper();

        //    return mapper.Map<Usuario>(request);
        //}

    }
}
