using EventSourcingProject.Domains.Write;
using EventSourcingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Infrastructure
{
    public class InMemoryWritePersistance<TAggregateId>
    {
        public static IList<IDomainEvent<TAggregateId>> domainEvents = new List<IDomainEvent<TAggregateId>>();

    }

    public class InMemoryReadPersistance
    {
        public static IList<MemoryPersistanceDomainEventModel> publishedEvents = new List<MemoryPersistanceDomainEventModel>();
        public static IList<BookLoan> readOrders = new List<BookLoan>();
    }
}
