using Helper;
using Helper.Enums;
using Helper.mediatr;
using Helper.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper.Handlers
{
    public class EmployeeRequestHandler : IRequestHandler<Request<Employee>, Response<Employee>>
    {
        private readonly IRepository<Employee> repository;

        public EmployeeRequestHandler(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        public Task<Response<Employee>> Handle(Request<Employee> request, CancellationToken cancellationToken)
        {
            Response<Employee> res = new Response<Employee>();
            if (request.Type == RequestType.GetAll)
            {
                res.Entity = repository.GetAll();
            }
            else if (request.Type == RequestType.Get)
            {
                res.Entity = repository.Get(request.ID);
            }
            else if (request.Type == RequestType.Add)
            {
                repository.Add(request.Entity);
            }
            else if (request.Type == RequestType.Update)
            {
                repository.Update(request.ID,request.Entity);
            }
            else if (request.Type == RequestType.Delete)
            {
                repository.Delete(request.ID);
            }
            return Task.FromResult(res);
        }
    }
}
