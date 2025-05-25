 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface.Persistence; 

namespace Web.Api.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    { 
        public IProductoRepository Productos { get; }
        public UnitOfWork( 
            IProductoRepository productos )
            
        { 
            Productos = productos; 
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
