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
            GenericRequestHandler<Employee> genericRequestHandler = new GenericRequestHandler<Employee>(repository);
            return genericRequestHandler.Handle(request, cancellationToken);
        }
    }
}
