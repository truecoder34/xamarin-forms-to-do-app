using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoCP.Data
{
    //[Table("Tasks")]
    public class ToDoTask : Entity
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
