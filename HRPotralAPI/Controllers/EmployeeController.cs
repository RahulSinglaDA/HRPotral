using HRPotralAPI.Models;
using HRPotralAPI.Repositories.EmployeeRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HRPotralAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository empRep;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            empRep = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return empRep.GetAll();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return empRep.Get(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post(Employee emp)
        {
            empRep.Add(emp);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, Employee emp)
        {
            empRep.Update(id, emp);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            empRep.Delete(id);
        }
    }
}
