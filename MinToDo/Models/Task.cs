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

        public Task(int id,string title)
        {
            Id = id;
            Title = title;

        }

        public Task(string title = "")
        {
            Title = title;
        }

        public Task()
        {
            Title = "";
        }
        
    }
}
