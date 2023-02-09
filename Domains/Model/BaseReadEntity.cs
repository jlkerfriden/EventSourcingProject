using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Model
{
    public abstract class BaseReadEntity
    {
        public string aggregateId { get; set; }
    }
}
