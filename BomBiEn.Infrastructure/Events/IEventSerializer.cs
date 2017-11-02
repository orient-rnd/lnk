using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Events
{
    public interface IEventSerializer
    {
        string SerializeEvent<TEvent>(TEvent @event) where TEvent : IEvent;

        IEvent DeserializeEvent(string @event);
    }
}