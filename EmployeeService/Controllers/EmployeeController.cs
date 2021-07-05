using Helper;
using Helper.Enums;
using Helper.Mediator;
using Helper.mediatr;
using Helper.Models;
using MediatR;
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
        private readonly IMediator mediator;

        public EmployeeController(IRepository<Employee> employeeRepository, IMediator mediator=null)
        {
            empRep = employeeRepository;
            this.mediator = mediator;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            System.Diagnostics.Debug.WriteLine("Welcome");
            ConcreteMediator.Instance.emp = new Employee(ConcreteMediator.Instance);
            ConcreteMediator.Instance.dep = new Department(ConcreteMediator.Instance);
            ConcreteMediator.Instance.emp.Send();
            Request<Employee> res = new Request<Employee>();
            res.Type = RequestType.Get;
            Response<Employee> empRes = await mediator.Send(res);
            return (IEnumerable<Employee>)empRes.Entity;
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
