using Helper;
using Helper.Models;
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

        private IRepository<Department> depRep;
        public DepartmentController(IRepository<Department> departmentRepository)
        {
            depRep = departmentRepository;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return depRep.GetAll();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public Department Get(int id)
        {
            return depRep.Get(id);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public void Post([FromBody] Department dep)
        {
            depRep.Add(dep);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Department dep)
        {
            depRep.Update(id, dep);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            depRep.Delete(id);
        }
    }
}
