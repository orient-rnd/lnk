using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BomBiEn.Infrastructure.Events
{
    public class EventSerializer : IEventSerializer
    {
        static EventSerializer()
        {
            DefaultSettings = new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                FloatFormatHandling = FloatFormatHandling.DefaultValue,
                NullValueHandling = NullValueHandling.Include,
                PreserveReferencesHandling = PreserveReferencesHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Error,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii,
                TypeNameHandling = TypeNameHandling.All
            };
        }

        public static JsonSerializerSettings DefaultSettings { get; private set; }

        public string SerializeEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return JsonConvert.SerializeObject(@event, DefaultSettings);
        }

        public IEvent DeserializeEvent(string @event)
        {
            return JsonConvert.DeserializeObject<IEvent>(@event, DefaultSettings);
        }
    }
}