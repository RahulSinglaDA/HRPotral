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
        private readonly IMediator mediator;

        public EmployeeController(IMediator mediator=null)
        {
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
            res.Type = RequestType.GetAll;
            Response<Employee> empRes = await mediator.Send(res);
            return (IEnumerable<Employee>)empRes.Entity;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> GetAsync(int id)
        {
            Request<Employee> res = new Request<Employee>();
            res.Type = RequestType.Get;
            res.ID = id;
            Response<Employee> empRes = await mediator.Send(res);
            return (Employee)empRes.Entity;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<OkResult> PostAsync(Employee emp)
        {
            Request<Employee> res = new Request<Employee>();
            res.Type = RequestType.Add;
            res.Entity = emp;
            Response<Employee> empRes = await mediator.Send(res);
            return new OkResult();
        }

        //PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, Employee emp)
        {
            Request<Employee> res = new Request<Employee>();
            res.Type = RequestType.Update;
            res.ID = id;
            res.Entity = emp;
            Response<Employee> empRes = await mediator.Send(res);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            Request<Employee> res = new Request<Employee>();
            res.Type = RequestType.Delete;
            res.ID = id;
            Response<Employee> empRes = await mediator.Send(res);
        }
    }
}
