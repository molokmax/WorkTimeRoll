using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Model
{
    public class TaskPersistModel : IPersistModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int FeatureId { get; set; }
    }
}
