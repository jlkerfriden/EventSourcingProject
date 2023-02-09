using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Model
{
    public  class CreateBookLoanCommand
    {
        public string customerId { get; set; }
        public string bookId { get; set; }
        public DateTime loanEndDate { get; set; }
    }
}
