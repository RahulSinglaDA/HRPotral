using Helper.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private readonly IBusControl _bus;

        public RabbitController(IBusControl bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee emp)
        {
            Uri uri = new Uri("rabbitmq://localhost/employee_queue");

            var endPoint = await _bus.GetSendEndpoint(uri);
            await endPoint.Send(emp);

            return Ok("Success");
        }
    }
}
