using EventSourcingProject.Domains.Model;
using EventSourcingProject.Domains.Write;
using EventSourcingProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Events
{
    public class BookLoanCreatedEvent : DomainEventBase<BookLoanAggregateId>
    {
        public string customerId { get; private set; }
        public string bookId { get; private set; }
        public DateTime loanEndDate { get; private set; }
        BookLoanCreatedEvent()
        {
        }

        internal BookLoanCreatedEvent(BookLoanAggregateId aggregateId, string customerId, string bookId, DateTime loanEndDate) : base(aggregateId)
        {
            this.customerId = customerId;
            this.bookId = bookId;
            this.loanEndDate = loanEndDate;
        }

        internal BookLoanCreatedEvent(BookLoanAggregateId aggregateId, long aggregateVersion, string customerId, string bookId, DateTime loanEndDate)
            : base(aggregateId, aggregateVersion)
        {
            this.customerId = customerId;
            this.bookId = bookId;
            this.loanEndDate = loanEndDate;
        }

        public override IDomainEvent<BookLoanAggregateId> WithAggregate(BookLoanAggregateId aggregateId, long aggregateVersion)
        {
            return new BookLoanCreatedEvent(aggregateId, aggregateVersion, customerId, bookId, loanEndDate);
        }

        public override string ToString() => ModelHelper.ToStringHelper(this);
    }
}
