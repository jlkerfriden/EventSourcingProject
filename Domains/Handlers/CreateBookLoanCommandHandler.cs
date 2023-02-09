using EventSourcingProject.Domains.EventPublisher;
using EventSourcingProject.Domains.Model;
using EventSourcingProject.Domains.Write;
using EventSourcingProject.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Handlers
{
    public class CreateBookLoanCommandHandler : ICommandHandler<CreateBookLoanCommand>
    {
        public void Handle(CreateBookLoanCommand command)
        {
            var aggregateId = new BookLoanAggregateId();
            var order = new BookLoanAggregate(aggregateId, command.customerId, command.bookId, command.loanEndDate);
            IDomainEventPublisher<BookLoanAggregateId> publisher = new InMemoryDomainEventPublisher<BookLoanAggregateId>();
            IWriteRepository<BookLoanAggregate, BookLoanAggregateId> repo = new InMemoryWriteRepository<BookLoanAggregate, BookLoanAggregateId>(publisher);
            repo.Save(order);
        }
    }
}
