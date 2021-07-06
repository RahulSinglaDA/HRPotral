using Helper;
using Helper.Handlers;
using Helper.mediatr;
using Helper.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DepartmentService
{
    public class DepartmentRequestHandler: IRequestHandler<Request<Department>, Response<Department>>
    {
        private readonly IRepository<Department> repository;

        public DepartmentRequestHandler(IRepository<Department> repository)
        {
            this.repository = repository;
        }

        public Task<Response<Department>> Handle(Request<Department> request, CancellationToken cancellationToken)
        {
            GenericRequestHandler<Department> genericRequestHandler = new GenericRequestHandler<Department>(repository);
            return genericRequestHandler.Handle(request, cancellationToken);
        }
    }
}
