using Persist.Database;
using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Repository
{
    public class TaskRepository : BaseCRUDRepository<TaskPersistModel>
    {
        public TaskRepository(IConnection connection) : base(connection)
        {

        }
    }
}
