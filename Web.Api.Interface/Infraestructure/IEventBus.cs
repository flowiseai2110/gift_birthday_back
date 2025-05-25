using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Interface.Infraestructure
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}
