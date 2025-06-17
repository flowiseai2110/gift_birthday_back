using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar.Productos;
using Web.Api.Interface.Persistence;
using Web.Api.Persistence.Context;

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

        public Task<IEnumerable<ProductoResponseDto>> GetProductoxFiltroAsync(ProductoRequestDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
