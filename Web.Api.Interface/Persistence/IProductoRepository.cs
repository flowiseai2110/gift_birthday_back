
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar.Productos;

namespace Web.Api.Interface.Persistence
{
    public interface IProductoRepository: IGenericRepository<Producto>
    {
      Task<IEnumerable<ProductoResponseDto>> GetProductoxFiltroAsync(ProductoRequestDto entity);
    }
}
/*
 Ecommerce
  VentaProducto
   VentaProductoDto 
   ListarProductosDto
   ListarAlternativasProducto
   VerDetalleProducto
  PagarProducto
    pagarProductoDto 
    GrabarProductoDto
 Gestionar
  GestionarProductoDto 
  GestionarArchivoDto
    
 */