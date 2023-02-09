using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.EventPublisher
{
    public interface IObserver
    {
        void update(string eventType);
    }
}
