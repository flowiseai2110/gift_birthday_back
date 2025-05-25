using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Web.Api.Interface.Persistence
{
    public interface IUnitOfWork : IDisposable
    { 
        IProductoRepository Productos { get; }
    }
}
