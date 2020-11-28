using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListBertoni.Models
{
    public class ToDoItem
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public ToDoStatus Status { get; set; }
    }

    public enum ToDoStatus
    {
        Incomplete,
        Complete
    }
}
