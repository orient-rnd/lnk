using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace BomBiEn.Infrastructure.Events
{
    public class InProcessEventBus : IEventBus
    {
        private readonly IComponentContext _componentContext;

        public InProcessEventBus(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
            IEnumerable<IEventHandler<TEvent>> eventHandlers = null;
            if (_componentContext.TryResolve<IEnumerable<IEventHandler<TEvent>>>(out eventHandlers))
            {
                foreach (IEventHandler<TEvent> eventHandler in eventHandlers)
                {
                    eventHandler.Handle(@event);
                }
            }
        }
    }
}