using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Model
{
    public class ProjectPersistModel : IPersistModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
