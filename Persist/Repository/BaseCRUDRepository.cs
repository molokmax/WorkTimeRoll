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
    public abstract class BaseCRUDRepository<TModel> : BaseReadRepository<TModel>, ICRUDRepository<TModel> where TModel : IPersistModel, new()
    {
        public BaseCRUDRepository(IConnection connection) : base(connection)
        {

        }

        public async Task<TModel> Insert(TModel record)
        {
            return await connection.Insert<TModel>(record);
        }

        public async Task<TModel> Update(TModel record)
        {
            return await connection.Update<TModel>(record);
        }

        public async Task<TModel> Delete(TModel record)
        {
            return await connection.Delete<TModel>(record);
        }

        public async Task Delete(int id)
        {
            await connection.Delete<TModel>(id);
        }

    }
}
