using HRPotralAPI.DBManagers;
using HRPotralAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private DBManager dBManager;
        public EmployeeRepository(DBManager dbManager)
        {
            this.dBManager = dbManager;
        }

        public void Add(Employee e)
        {
            dBManager.Employees.Add(e);
            dBManager.SaveChanges();
        }

        public Employee Get(int employeeID)
        {
            return dBManager.Employees.Where(e => e.EmployeeID == employeeID).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return dBManager.Employees;
        }

        public void Update(int id, Employee e)
        {
            Employee emp = dBManager.Employees.Where(ep => ep.EmployeeID == id).FirstOrDefault();
            emp.EmployeeName = e.EmployeeName;
            emp.EmployeeEmail = e.EmployeeEmail;
            emp.EmployeePhone = e.EmployeePhone;
            dBManager.SaveChanges();
        }

        public void Delete(int id)
        {
            Employee emp= dBManager.Employees.Where(e => e.EmployeeID == id).FirstOrDefault();
            dBManager.Employees.Remove(emp);
            dBManager.SaveChanges();
        }
    }
}
