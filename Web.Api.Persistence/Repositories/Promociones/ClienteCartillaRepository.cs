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
    public class ClienteCartillaRepository : IClienteCartillaRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public ClienteCartillaRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(ClienteCartilla entity)
        {
            _efContext.ClienteCartilla.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.cliente_cartilla_id;
        }

        public Task<IEnumerable<ClienteCartilla>> GetAllAsync(ClienteCartilla entity)
        {
            throw new NotImplementedException();
        }

        public ClienteCartilla? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(ClienteCartilla entity)
        {
            throw new NotImplementedException();
        }
    }
}
