using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface.Persistence;

namespace Web.Api.Interface
{
    public interface IUnitOfWork : IDisposable
    { 
       public IProductoRepository Productos { get; }
       public IEventoRepository Eventos { get; }
    }
}
