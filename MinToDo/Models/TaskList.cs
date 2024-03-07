using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinToDo.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task> Tasks { get; set; }

        public TaskList(int id, string title)
        {
            Id = id;
            Title = title;
            Tasks = new List<Task>();
        }
        public TaskList(string title = "")
        {
            Title = title;
            Tasks = new List<Task>();
        }
        
        public static readonly TaskList Default = new()
        {
            Title = "My List",
            Tasks = new List<Task>()
            {
                new Task("New Task")
            }

        };
    }
}
