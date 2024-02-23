using MinToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinToDo.Repositories
{
    public class TaskListRepository
    {
        private JSONDataAccess _JSONDataAccess { get; set; }
        
        public TaskListRepository()
        {
            _JSONDataAccess = new JSONDataAccess();
            

        }

        public List<TaskList> GetLists()
        {

            return _JSONDataAccess.GetLists();

        }
        public void AddList(TaskList taskList)
        {
            _JSONDataAccess.AddList(taskList);
            _JSONDataAccess.Save();
        }

        public void RemoveList(TaskList taskList) 
        {
            _JSONDataAccess.RemoveList(taskList);
            _JSONDataAccess.Save();
        }

        public void AddTask(TaskList taskList, Task task)
        {
            _JSONDataAccess.AddTask(taskList, task);
            _JSONDataAccess.Save();
        }

        public void RemoveTask(TaskList taskList, Task task)
        {
            _JSONDataAccess.RemoveTask(taskList, task);
            _JSONDataAccess.Save();
        }

    }
}
