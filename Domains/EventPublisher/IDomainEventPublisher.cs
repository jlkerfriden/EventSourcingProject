using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.EventPublisher
{
    // Credits to : https://github.com/mickeysden
    public interface IDomainEventPublisher<TAggregateId>
    {
        void publishEvent(string eventType, string aggregateId, IDictionary<string, object> eventData);
    }
}
