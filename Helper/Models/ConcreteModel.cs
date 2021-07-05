using Helper.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models
{
    public abstract class ConcreteModel
    {
        public IMediatorC mediator;
        public ConcreteModel() { }
        public ConcreteModel(IMediatorC mediator)
        {
            this.mediator = mediator;
        }

    }
}
