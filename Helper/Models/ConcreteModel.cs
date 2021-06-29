﻿using Helper.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models
{
    public abstract class ConcreteModel
    {
        public IMediator mediator;
        public ConcreteModel() { }
        public ConcreteModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

    }
}