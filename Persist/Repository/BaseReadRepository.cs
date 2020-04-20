using Microsoft.Extensions.Configuration;
using Persist.Database;
using Persist.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Repository
{
    public abstract class BaseReadRepository<TModel> : IReadRepository<TModel> where TModel : IPersistModel, new()
    {
        protected readonly IConnection connection;
        public BaseReadRepository(IConnection connection)
        {
            this.connection = connection;
        }

        public async Task<TModel> Get(int id)
        {
            return await connection.Get<TModel>(id);
        }

        public async Task<IQueryable<TModel>> Get()
        {
            List<TModel> result = await connection.GetAll<TModel>();
            return result.AsQueryable(); // TODO it is hell!!
        }

    }
}
