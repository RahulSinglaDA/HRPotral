using Helper.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.mediatr
{
    public class Request<T>:IRequest<Response<T>>
    {
        public RequestType Type { get; set; }

        public int ID { get; set; }
        public T Entity { get; set; }

        public static Request<T> CreateRequest()
        {
            return new Request<T>();
        }
    }
}
