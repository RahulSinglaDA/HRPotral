using Helper;
using Helper.Enums;
using Helper.mediatr;
using Helper.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DepartmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator mediator = null)
        {
            this.mediator = mediator;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<IEnumerable<Department>> GetAsync()
        {
            Request<Department> res = new Request<Department>();
            res.Type = RequestType.GetAll;
            Response<Department> empRes = await mediator.Send(res);
            return (IEnumerable<Department>)empRes.Entity;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public async Task<Department> GetAsync(int id)
        {
            Request<Department> res = new Request<Department>();
            res.Type = RequestType.Get;
            res.ID = id;
            Response<Department> empRes = await mediator.Send(res);
            return (Department)empRes.Entity;
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<OkResult> PostAsync([FromBody] Department dep)
        {
            Request<Department> res = new Request<Department>();
            res.Type = RequestType.Add;
            res.Entity = dep;
            Response<Department> empRes = await mediator.Send(res);
            return new OkResult();
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] Department dep)
        {
            Request<Department> res = new Request<Department>();
            res.Type = RequestType.Update;
            res.ID = id;
            res.Entity = dep;
            Response<Department> empRes = await mediator.Send(res);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            Request<Department> res = new Request<Department>();
            res.Type = RequestType.Delete;
            res.ID = id;
            Response<Department> empRes = await mediator.Send(res);
        }
    }
}
