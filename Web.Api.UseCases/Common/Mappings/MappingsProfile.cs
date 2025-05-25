using AutoMapper; 
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Dto.Gestionar;
using Web.Api.Dto.Services.Productos;
using Web.Api.UseCases.Services.Cartillas.Command;
using Web.Api.UseCases.Services.Clientes.Command;
using Web.Api.UseCases.Services.Empresas.Command;
using Web.Api.UseCases.Services.LocalesComerciales.Command;
using Web.Api.UseCases.Services.Productos.Commands;
using Web.Api.UseCases.Services.Promociones.Command;
using Web.Api.UseCases.Services.Usuarios.Command;

namespace Web.Api.UseCases.Common.Mappings
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile() {

            CreateMap<CreateEmpresaCommand, Empresa>().ReverseMap();
            CreateMap<EmpresaDto, Empresa>().ReverseMap();

            CreateMap<CreateLocalComercialCommand, LocalComercial>().ReverseMap();
            CreateMap<LocalComercial, LocalComercialDto>().ReverseMap();

            CreateMap<CreateUsuarioCommand, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<CreateCartillaCommand, CartillaDto>().ReverseMap();
            CreateMap<Cartilla, CartillaDto>().ReverseMap();

            CreateMap<CreateClienteCommand, Cliente>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();

            CreateMap<CreatePromocionCommand, CPromocion>().ReverseMap();
            CreateMap<CPromocion, CPromocionDto>().ReverseMap();

            CreateMap<ProductoDto, Producto>().ReverseMap();
            CreateMap<ProductoImagenDto, ProductoImagen>().ReverseMap();

        }
    }
}
