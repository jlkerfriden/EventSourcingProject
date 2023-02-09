using EventSourcingProject.Domains.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Model
{
    public class BookLoan : BaseReadEntity
    {
        public string customerId { get; set; }
        public string bookId { get; set; }
        public DateTime loanEndDate { get; set; }


        public BookLoan(string id, string customerId, string bookId, DateTime loanEndDate)
        {
            aggregateId = id;
            this.customerId = customerId;
            this.bookId = bookId;
            this.loanEndDate = loanEndDate;
        }
    }
}
