using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Interface.Infraestructure;
using MassTransit;

namespace Web.Api.Infraestructure.EventBus
{
    public class EventBusRabbitMQ : IEventBus
    {
        private readonly IPublishEndpoint _publishEndPoint;

        public EventBusRabbitMQ(IPublishEndpoint publishEndPoint)
        {
            _publishEndPoint = publishEndPoint;
        }

        public async void Publish<T>(T @event)
        {
            await _publishEndPoint.Publish(@event);
        }
    }
}
