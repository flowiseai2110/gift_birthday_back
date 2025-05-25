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
    public class ClienteRepository : IClienteRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public ClienteRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public async Task<int> CreateAsync(Cliente entity)
        {
            _efContext.Cliente.Add(entity);
            await _efContext.SaveChangesAsync();

            return entity.cliente_id;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync(Cliente entity)
        {
            var result = _efContext.Cliente.Where(x => x.local_comercial_id == entity.local_comercial_id);

            return result.ToList();
        }

        public Cliente? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
