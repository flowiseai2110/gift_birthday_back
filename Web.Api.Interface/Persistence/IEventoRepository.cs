using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Domain.Entities;
using Web.Api.Dto.Gestionar.Productos;

namespace Web.Api.Interface.Persistence
{

    public interface IEventoRepository : IGenericRepository<EventoBE>
    { 
    }
}
