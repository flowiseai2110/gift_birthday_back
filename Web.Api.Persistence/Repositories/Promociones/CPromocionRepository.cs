using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities.proceso;
using Web.Api.Interface.Persistence.Promocion;
using Web.Api.Persistence.Context.Promocion;

namespace Web.Api.Persistence.Repositories.Promociones
{
    public class CPromocionRepository: ICPromocionRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public CPromocionRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(CPromocion entity)
        {
            _efContext.CPromocion.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.promocion_id;
        }

        public async Task<IEnumerable<CPromocion>> GetAllAsync(CPromocion entity)
        {
            var result = _efContext.CPromocion.Where(x => x.local_comercial_id == entity.local_comercial_id);

            return result.ToList();
        }

        public CPromocion? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(CPromocion entity)
        {
            throw new NotImplementedException();
        }
    }
}
