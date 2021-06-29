using HRPotralAPI.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Models
{
    public class Department : ConcreteModel
    {
        public Department() { }
        public Department(IMediator mediator) : base(mediator) { }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public void Send()
        {
            mediator.SendMessage(Mediator.Models.Department, "Hello from Department!");
        }

        public void Recieve(string msg)
        {
            System.Diagnostics.Debug.WriteLine("Message Recieved in Department");
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}
