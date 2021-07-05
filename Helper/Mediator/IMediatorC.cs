using Helper.mediatr;
using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Mediator
{

    public enum Models
    {
        Employee,
        Department
    }


    public interface IMediatorC
    {
        public void SendMessage(Models name,string msg);
    }
}
