using AutoMapper; 
using Web.Api.Domain.Entities;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Dto.Gestionar;
using Web.Api.Dto.Services.Productos;  
using Web.Api.UseCases.Services.Productos.Commands;
 

namespace Web.Api.UseCases.Common.Mappings
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile() {

             
            CreateMap<ProductoDto, Producto>().ReverseMap();
            CreateMap<ProductoImagenDto, ProductoImagen>().ReverseMap();

        }
    }
}
