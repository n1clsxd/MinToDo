using MinToDo.Models;
using System.Collections.Generic;

namespace MinToDo.Repositories
{
    public class TaskListRepository
    {
        private JsonDataAccess JsonDataAccess { get; set; }

        public TaskListRepository()
        {
            JsonDataAccess = new JsonDataAccess();
        }

        public List<TaskList> GetLists()
        {
            return JsonDataAccess.TaskLists;
        }
        public void AddList(TaskList taskList)
        {
            JsonDataAccess.AddList(taskList);
            JsonDataAccess.Persist();
        }

        public void RemoveList(TaskList taskList)
        {
            JsonDataAccess.RemoveList(taskList);
            JsonDataAccess.Persist();
        }

        public void AddTask(TaskList taskList, Task task)
        {
            JsonDataAccess.AddTask(taskList, task);
            JsonDataAccess.Persist();
        }

        public void RemoveTask(TaskList taskList, Task task)
        {
            JsonDataAccess.RemoveTask(taskList, task);
            JsonDataAccess.Persist();
        }
    }
}
