using Persist.Database;
using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Repository
{
    public class ProjectRepository : BaseCRUDRepository<ProjectPersistModel>
    {
        public ProjectRepository(IConnection connection) : base(connection)
        {

        }
    }
}
