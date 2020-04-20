using Persist.Database;
using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Repository
{
    public class ProgressRepository : BaseCRUDRepository<ProgressPersistModel>
    {
        public ProgressRepository(IConnection connection) : base(connection)
        {

        }
    }
}
