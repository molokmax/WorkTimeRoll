using Persist.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Handler
{
    public abstract class BaseHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
    {
        protected readonly IConnection connection;
        public BaseHandler(IConnection connection)
        {
            this.connection = connection;
        }

        public async Task<TResponse> Execute(TRequest request)
        {
            try
            {
                return await Body(request);
            }
            catch (Exception e)
            {
                // TODO: log
                throw;
            }
        }

        protected abstract Task<TResponse> Body(TRequest request);
    }
}
