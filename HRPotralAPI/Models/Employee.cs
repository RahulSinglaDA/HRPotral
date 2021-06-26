using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Models
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public int EmployeePhone { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

    }
}
