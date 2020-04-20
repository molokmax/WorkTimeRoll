using Persist.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persist.Repository
{
    public interface IReadRepository<TModel> where TModel: IPersistModel, new()
    {
        Task<TModel> Get(int id);
        Task<IQueryable<TModel>> Get();
    }
}
