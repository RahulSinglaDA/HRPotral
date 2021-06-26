using HRPotralAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public void Add(Employee e);
        public Employee Get(int employeeID);
        public void Update(int id, Employee e);
        public IEnumerable<Employee> GetAll();
        public void Delete(int id);
    }
}
