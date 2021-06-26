using HRPotralAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRPotralAPI.Repositories.DepartmentRepository
{
    public interface IDepartmentRepository
    {
        public void Add(Department e);
        public Department Get(int employeeID);
        public void Update(int id, Department e);
        public IEnumerable<Department> GetAll();
        public void Delete(int id);
    }
}
