using EventSourcingProject.Domains;
using EventSourcingProject.Helpers;
using EventSourcingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Infrastructure
{
    public class InMemoryReadRepository : IReadRepository
    {
        public void UpdateReadModelOnEventPublish(string eventType)
        {
            SimpleLogger.Log("updates for " + eventType);
            var latestPublishedEvent = InMemoryReadPersistance.publishedEvents.OrderByDescending(x => x.eventDate).FirstOrDefault();
            switch (latestPublishedEvent.eventType)
            {
                case "OrderCreatedEvent":
                    if (InMemoryReadPersistance.readOrders.Where(x => x.aggregateId == latestPublishedEvent.aggregateId.ToString()).FirstOrDefault() == null)
                        InMemoryReadPersistance.readOrders.Add(new BookLoan(
                            latestPublishedEvent.aggregateId.ToString(),
                            latestPublishedEvent.eventData["customerId"].ToString(),
                            latestPublishedEvent.eventData["bookId"].ToString(),
                            (DateTime)latestPublishedEvent.eventData["loanEndDate"]));
                    break;
                default: SimpleLogger.Log("Not tracking this event"); break;
            }
        }

        private static BookLoan CopyOrder(BookLoan bookloan)
        {
            var updatedOrder = new BookLoan(bookloan.aggregateId, bookloan.customerId, bookloan.bookId, bookloan.loanEndDate);
            return updatedOrder;
        }
    }
}
