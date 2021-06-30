using Helper.Mediator;
using Helper.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository<Employee> empRep;
        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            empRep = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            System.Diagnostics.Debug.WriteLine("Welcome");
            ConcreteMediator.Instance.emp = new Employee(ConcreteMediator.Instance);
            ConcreteMediator.Instance.dep = new Department(ConcreteMediator.Instance);
            ConcreteMediator.Instance.emp.Send();

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
        public OkResult Post(Employee emp)
        {
            empRep.Add(emp);
            return new OkResult();
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
