using Helper;
using Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentService
{
    public class DepartmentRepository : IRepository<Department>
    {
        private DBManager dBManager;
        public DepartmentRepository(DBManager dbManager)
        {
            this.dBManager = dbManager;
        }

        public void Add(Department dep)
        {
            dBManager.Departments.Add(dep);
            dBManager.SaveChangesAsync();
        }

        public Department Get(int departmentID)
        {
            return dBManager.Departments.Where(e => e.DepartmentID == departmentID).FirstOrDefault();
        }

        public IEnumerable<Department> GetAll()
        {
            return dBManager.Departments;
        }

        public void Update(int id, Department dep)
        {
            Department dept = dBManager.Departments.Where(ep => ep.DepartmentID == id).FirstOrDefault();
            dept.DepartmentName = dep.DepartmentName;
            dBManager.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            Department dep = dBManager.Departments.Where(e => e.DepartmentID == id).FirstOrDefault();
            dBManager.Departments.Remove(dep);
            dBManager.SaveChangesAsync();
        }
    }
}
