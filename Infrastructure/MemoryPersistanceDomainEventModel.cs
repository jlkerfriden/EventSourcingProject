using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Infrastructure
{
    public class MemoryPersistanceDomainEventModel
    {
        public string eventType { get; set; }
        public string aggregateId { get; set; }
        public DateTime eventDate { get; set; }
        public IDictionary<string, object> eventData { get; set; }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("\n--------------------Published event " + eventType + "------------------\n");
            stringBuilder.Append("\naggregateId : " + aggregateId);
            stringBuilder.Append("\neventDate : " + eventDate.ToString());
            foreach (var key in eventData.Keys) stringBuilder.Append("\n" + key + " : " + (eventData[key] == null ? "" : eventData[key]));
            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }
    }
}
