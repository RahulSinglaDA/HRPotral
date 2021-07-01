using Helper.Models;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentService
{
    public class EmployeeConsumer :
          IConsumer<Employee>
    {
        public async Task Consume(ConsumeContext<Employee> context)
        {
            var data = context.Message;
            // message received.
        }
    }

}
