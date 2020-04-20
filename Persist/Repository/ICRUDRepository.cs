using Persist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Repository
{
    public interface ICRUDRepository<TModel> : IReadRepository<TModel> where TModel: IPersistModel, new()
    {
        Task<TModel> Insert(TModel record);
        Task<TModel> Update(TModel record);
        Task<TModel> Delete(TModel record);
        Task Delete(int id);
    }
}
