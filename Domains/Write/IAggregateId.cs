using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Write
{
    public interface IAggregateId
    {
        string IdAsString();
    }
}
