using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public interface IHandler<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
