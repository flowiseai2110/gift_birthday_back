using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.config;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Interface.Persistence.Promocion;
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Interface.Persistence.Promociones
{
    public class CartillaPromocionRepository : ICartillaPromocionRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public CartillaPromocionRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(CartillaPromocion entity)
        {
            _efContext.CartillaPromocion.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.cartilla_promocion_id;
        }

        public Task<IEnumerable<CartillaPromocion>> GetAllAsync(CartillaPromocion entity)
        {
            throw new NotImplementedException();
        }

        public CartillaPromocion? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(CartillaPromocion entity)
        {
            throw new NotImplementedException();
        }
    }
}
