using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persist.Model
{
    public class ProgressPersistModel : IPersistModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public TimeSpan RealEffort { get; set; }
        public TimeSpan PublicEffort { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TaskId { get; set; }
    }
}
