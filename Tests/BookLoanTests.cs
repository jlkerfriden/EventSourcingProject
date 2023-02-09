using EventSourcingProject.Domains;
using EventSourcingProject.Domains.Handlers;
using EventSourcingProject.Domains.Model;
using EventSourcingProject.Infrastructure;
using EventSourcingProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Tests
{
    public class BookLoanTests
    {
        public BookLoanTests()
        {

        }

        [Fact]
        public void GIvenNoBookExists_WhenCreateOne_ThenBookCreadtedEven()
        {
            var dispatcher = new CommandDispatcher();

            dispatcher.Dispatch(new CreateBookLoanCommand()
            {
                customerId = "JamesWebb",
                bookId = "Telescope",
                loanEndDate = DateTime.Now.AddDays(15),
            });

            Assert.True(InMemoryReadPersistance.publishedEvents[InMemoryReadPersistance.publishedEvents.Count - 1].eventType == "BookLoanCreatedEvent");
        }

        [Fact]
        public void GivenEventPublished_WhenOrderRelatedEvent_ThenUpdateOrderReadModel()
        {
            //Given
            var latestPublishedEvent = InMemoryReadPersistance.publishedEvents.OrderByDescending(x => x.eventDate).FirstOrDefault();

            //When
            if (latestPublishedEvent != null && BookLoanRelatedEvents().Contains(latestPublishedEvent.eventType))
            {
                //Then
                IReadRepository repo = new InMemoryReadRepository();
                repo.UpdateReadModelOnEventPublish(latestPublishedEvent.eventType);
                Assert.True(InMemoryReadPersistance.readOrders.Where(x => x.aggregateId == latestPublishedEvent.aggregateId).FirstOrDefault() != null);
            }
        }

        private static HashSet<string> BookLoanRelatedEvents()
        {
            var set = new HashSet<string>();
            set.Add("BookLoanCreatedEvent");
            return set;
        }
    }
}
