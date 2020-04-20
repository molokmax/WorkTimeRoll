using Persist.Database;
using Persist.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Repository
{
    public class FeatureRepository : BaseCRUDRepository<FeaturePersistModel>
    {
        public FeatureRepository(IConnection connection) : base(connection)
        {

        }
    }
}
