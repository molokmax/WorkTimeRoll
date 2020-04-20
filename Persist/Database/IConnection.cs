using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Database
{
    public interface IConnection : IDisposable
    {
        Task CreateDatabase(Type[] tables);

        Task<TModel> Get<TModel>(int id) where TModel : IPersistModel, new();

        Task<List<TModel>> GetAll<TModel>() where TModel : IPersistModel, new();

        Task<TModel> Insert<TModel>(TModel record) where TModel : IPersistModel, new();

        Task<TModel> Update<TModel>(TModel record) where TModel : IPersistModel, new();

        Task<TModel> Delete<TModel>(TModel record) where TModel : IPersistModel, new();

        Task Delete<TModel>(int id) where TModel : IPersistModel, new();
    }
}
