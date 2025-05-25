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
    public class ClienteCartillaDetalleRepository : IClienteCartillaDetalleRepository
    {
        private readonly PromocionContext _efContext;
        private readonly DapperPromocionContext _dapperContext;

        public ClienteCartillaDetalleRepository(PromocionContext efContext, DapperPromocionContext dapperContext)
        {
            _efContext = efContext;
            _dapperContext = dapperContext;
        }

        public Task<int> CreateAsync(ClienteCartillaDetalle entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteCartillaDetalle>> GetAllAsync(ClienteCartillaDetalle entity)
        {
            throw new NotImplementedException();
        }

        public ClienteCartillaDetalle? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(ClienteCartillaDetalle entity)
        {
            throw new NotImplementedException();
        }
    }
}
