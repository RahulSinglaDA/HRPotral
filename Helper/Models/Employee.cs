using Helper.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models
{
    public class Employee : ConcreteModel
    {
        public Employee() { }
        public Employee(IMediator mediator) : base(mediator) { }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeePhone { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }


        public void Send()
        {
            mediator.SendMessage(Mediator.Models.Employee,"Hello from Employee!");
        }

        public void Recieve(string msg)
        {
            System.Diagnostics.Debug.WriteLine("Message Recieved in Employee");
            System.Diagnostics.Debug.WriteLine(msg);
        }
    }
}
