
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface;
using Web.Api.Interface.Persistence;

namespace Web.Api.Persistence
{
    public class UnitOfWork : IUnitOfWork
    { 
        public IProductoRepository Productos { get; }

        public IEventoRepository Eventos { get; }

        public UnitOfWork( 
            IProductoRepository productos, IEventoRepository eventos)
            
        { 
            Productos = productos; 
            Eventos = eventos;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
