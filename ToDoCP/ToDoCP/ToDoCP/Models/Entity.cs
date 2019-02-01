using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ToDoCP.Data
{
    public class Entity
    {
        [PrimaryKey]
        public Guid NoteId { get; set; }
        public Entity()
        {
            NoteId = Guid.NewGuid();
        }
    }
}
