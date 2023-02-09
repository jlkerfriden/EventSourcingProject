using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Write
{
    public interface IDomainEvent<TAggregateId>
    {
        Guid eventId { get; }
        TAggregateId aggregateId { get; }
        long aggregateVersion { get; }
        DateTime eventDate { get; }
        string eventType { get; }
    }
}
