using System;

namespace ToDoList.DataAccess.Entities
{
    public sealed class TodoEntry
    {
        public long Id { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? CompletedDateTime { get; set; }

        public string ActionTitle { get; set; }

        public string ActionDescription { get; set; }
    }
}
