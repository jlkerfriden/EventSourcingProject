﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingProject.Domains.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand : class
    {
        void Handle(TCommand command);
    }
}
