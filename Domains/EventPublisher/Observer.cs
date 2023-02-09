using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.EventPublisher
{
    public class Observer : IObserver
    {
        private IReadRepository repository;
        public Observer(IReadRepository repo, ISubject subject)
        {
            repository = repo;
            subject.RegisterObserver(this);
        }

        public void update(string eventType)
        {
            repository.UpdateReadModelOnEventPublish(eventType);
        }
    }
}
