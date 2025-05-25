using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Dto.Services.Productos;

namespace Web.Api.Interface.UseCases.Servicios.Productos
{
    public interface IProductoService
    {
         Task<IEnumerable<ProductoDto>> ListarProducto();
         Task<bool> GuardarProducto(ProductoDto productoData);
         Task<IEnumerable<ProductoImagenDto>> ListarProductoImagen();
         Task<bool> GuardarProductoImagen(ProductoImagenDto productoImagenDto);
    }
}
