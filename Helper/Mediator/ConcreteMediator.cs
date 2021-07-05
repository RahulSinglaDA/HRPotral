using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Mediator
{

    public class ConcreteMediator : IMediatorC
    {
        public Employee emp;
        public Department dep;

        private ConcreteMediator() { }

        private static ConcreteMediator instance;
        public static ConcreteMediator Instance
        {
            get 
            { 
            if (instance == null)
                {
                    instance = new ConcreteMediator();
                }
                return instance;
            }
        }

        public void SendMessage(Models name, string msg)
        {
            if(name==Models.Employee)
            {
                dep.Recieve(msg); 
            }
            else
            {
                emp.Recieve(msg);
            }
        }
    }
}
