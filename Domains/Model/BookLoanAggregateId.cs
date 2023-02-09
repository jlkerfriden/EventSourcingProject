using EventSourcingProject.Domains.Write;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Model
{
    public class BookLoanAggregateId : IAggregateId
    {
        public BookLoanAggregateId()
        {
            id = Guid.NewGuid();
        }

        public BookLoanAggregateId(string aggregateIdString)
        {
            id = Guid.Parse(aggregateIdString);
        }
        public Guid id { get; private set; }
        public string IdAsString() => id.ToString();
        public override string ToString() => IdAsString();
    }
}
