using EventSourcingProject.Domains.EventPublisher;
using EventSourcingProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventSourcingProject.Infrastructure
{
    public class InMemoryDomainEventPublisher<TAggregateId> : IDomainEventPublisher<TAggregateId>
    {
        private Subject subject;
        private Observer observer;
        public InMemoryDomainEventPublisher()
        {
            subject = new Subject();
            observer = new Observer(new InMemoryReadRepository(), subject);
        }
        public void publishEvent(string eventType, string aggregateId, IDictionary<string, object> eventData)
        {
            InMemoryReadPersistance.publishedEvents.Add(new MemoryPersistanceDomainEventModel()
            {
                eventType = eventType,
                eventDate = DateTime.Now,
                aggregateId = aggregateId,
                eventData = eventData
            });
            SimpleLogger.Log(eventType + " " + aggregateId);
            subject.setEventPublished(eventType);
        }
    }
}
