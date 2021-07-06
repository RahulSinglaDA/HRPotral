using Helper.Enums;
using Helper.mediatr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper.Handlers
{
    class GenericRequestHandler<T> 
    {
        private readonly IRepository<T> repository;

        public GenericRequestHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public Task<Response<T>> Handle(Request<T> request, CancellationToken cancellationToken)
        {
            Response<T> res = new Response<T>();
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
                repository.Update(request.ID, request.Entity);
            }
            else if (request.Type == RequestType.Delete)
            {
                repository.Delete(request.ID);
            }
            return Task.FromResult(res);
        }
    }
}
