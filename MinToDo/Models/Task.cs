using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinToDo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public Task(int id,string title, bool isDone)
        {
            Id = id;
            Title = title;
            IsDone = isDone;
        }
    }
}
