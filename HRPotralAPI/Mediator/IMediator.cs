using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Mediator
{

    public enum Models
    {
        Employee,
        Department
    }


    public interface IMediator
    {
        public void SendMessage(Models name,string msg);
    }
}
