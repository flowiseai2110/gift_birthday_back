using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar.Productos;
using Web.Api.Interface.Persistence;
using Web.Api.Persistence.Context;
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Persistence.Repositories.Ecommerce
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationContext _efContext;
        public ProductoRepository(ApplicationContext efContext)
        {
            _efContext = efContext; 
        }

        public Task<int> CreateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Producto>> GetAllAsync(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Producto? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductoResponseDto>> GetProductoxFiltroAsync(ProductoRequestDto entity)
        {
            var result =  from producto in _efContext.Producto join producto_imagen in _efContext.ProductoImagen on producto.productoId equals producto_imagen.productoId
                          select new ProductoResponseDto {
                             nombre = producto.nombre,
                             descripcion = producto.descripcion,
                             precio_venta = producto.precioVenta,
                             nombre_archivo = producto_imagen.nombreArchivo,
                             url_archivo = producto_imagen.urlArchivo 
                          };
            return result;
        }

        public bool UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
