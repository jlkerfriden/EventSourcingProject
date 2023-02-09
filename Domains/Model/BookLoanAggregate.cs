using EventSourcingProject.Domains.Events;
using EventSourcingProject.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Model
{
    public class BookLoanAggregate : AggregateBase<BookLoanAggregateId>
    {
        public BookLoanAggregate(BookLoanAggregateId aggregateId, string customerId, string bookId, DateTime loanEndDate)
        {
            if (aggregateId == null) throw new ArgumentNullException(nameof(aggregateId));
            if (String.IsNullOrEmpty(customerId)) throw new ArgumentNullException(nameof(customerId));
            if (String.IsNullOrEmpty(bookId)) throw new ArgumentNullException(nameof(bookId));
            RaiseEvent(new BookLoanCreatedEvent(aggregateId, customerId, bookId, loanEndDate));
        }

        private BookLoanAggregate()
        {
            
        }

        internal void Apply(BookLoanCreatedEvent ev)
        {
            id = ev.aggregateId;
            customerId = ev.customerId;
            bookId = ev.bookId;
            loanEndDate = ev.loanEndDate;
        }

        public string customerId { get; private set; }
        public string bookId { get; private set; }
        public DateTime loanEndDate { get; private set; }
        public override string ToString() => ModelHelper.ToStringHelper(this);
    }
}
