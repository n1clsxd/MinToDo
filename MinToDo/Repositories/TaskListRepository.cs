using MinToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinToDo.Repositories
{
    public class TaskListRepository
    {
        private JsonDataAccess _JsonDataAccess { get; set; }
        
        public TaskListRepository()
        {
            _JsonDataAccess = new JsonDataAccess();
            

        }

        public List<TaskList> GetLists()
        {

            return _JsonDataAccess.GetLists();

        }
        public void AddList(TaskList taskList)
        {
            _JsonDataAccess.AddList(taskList);
            _JsonDataAccess.Persist();
        }

        public void RemoveList(TaskList taskList) 
        {
            _JsonDataAccess.RemoveList(taskList);
            _JsonDataAccess.Persist();
        }

        public void AddTask(TaskList taskList, Task task)
        {
            _JsonDataAccess.AddTask(taskList, task);
            _JsonDataAccess.Persist();
        }

        public void RemoveTask(TaskList taskList, Task task)
        {
            _JsonDataAccess.RemoveTask(taskList, task);
            _JsonDataAccess.Persist();
        }

    }
}
