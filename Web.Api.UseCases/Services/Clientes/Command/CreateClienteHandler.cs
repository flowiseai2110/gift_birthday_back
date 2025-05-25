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
using Web.Api.UseCases.Services.Cartillas.Command;
using Web.Api.UseCases.Services.Promociones.Command;
using Web.Api.UseCases.Services.Usuarios.Command;

namespace Web.Api.UseCases.Services.Clientes.Command
{
    public class CreateClienteHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateClienteHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var obj = _mapper.Map<Cliente>(request);
            obj.activo = true;
            obj.fechaRegistro = DateTime.UtcNow;

            var result = await _unitOfWork.Cliente.CreateAsync(obj);

            return result;
        }
        //public Cliente MapperCliente(CreateClienteCommand request)
        //{
        //    var mapConfig = new MapperConfiguration(
        //            cfg => cfg.CreateMap<CreateClienteCommand, Cliente>()
        //            .ForMember(dest => dest.i_cliente_id, opt => opt.MapFrom(src => src.cliente_id))
        //            .ForMember(dest => dest.i_local_comercial_id, opt => opt.MapFrom(src => src.local_comercial_id))
        //            .ForMember(dest => dest.v_numero_documento, opt => opt.MapFrom(src => src.numero_documento))
        //            .ForMember(dest => dest.v_tipo_documento, opt => opt.MapFrom(src => src.tipo_documento))
        //            .ForMember(dest => dest.v_tipo_cliente, opt => opt.MapFrom(src => src.tipo_cliente))
        //            .ForMember(dest => dest.v_nombre, opt => opt.MapFrom(src => src.nombre))
        //            .ForMember(dest => dest.v_apellido_paterno, opt => opt.MapFrom(src => src.apellido_paterno))
        //            .ForMember(dest => dest.v_apellido_materno, opt => opt.MapFrom(src => src.apellido_materno))
        //            .ForMember(dest => dest.d_fecha_nacimiento, opt => opt.MapFrom(src => src.fecha_nacimiento))
        //            .ForMember(dest => dest.v_celular, opt => opt.MapFrom(src => src.celular))
        //            .ForMember(dest => dest.v_correo_electronico, opt => opt.MapFrom(src => src.correo_electronico))
        //            .ForMember(dest => dest.usuario_registro, opt => opt.MapFrom(src => src.usuario_registro))
        //        );

        //    var mapper = mapConfig.CreateMapper();

        //    return mapper.Map<Cliente>(request);
        //}
    }
}
