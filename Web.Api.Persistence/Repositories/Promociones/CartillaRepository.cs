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
    public class CartillaRepository : ICartillaRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public CartillaRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(Cartilla entity)
        {
            _efContext.Cartilla.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.cartilla_id;
        }

        public async Task<IEnumerable<Cartilla>> GetAllAsync(Cartilla entity)
        {
            var result = _efContext.Cartilla.Where(x => x.local_comercial_id == entity.local_comercial_id);

            return result.ToList();
        }

        public Cartilla? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(Cartilla entity)
        {
            throw new NotImplementedException();
        }
    }
}
