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
        public List<TaskList> GetTaskLists()
        {
            return JsonDataAccess.TaskLists;
        }
        public void AddTaskList(TaskList taskList)
        {
            JsonDataAccess.AddTaskList(taskList);
            JsonDataAccess.Persist();
        }
        public void RemoveTaskList(TaskList taskList)
        {
            JsonDataAccess.RemoveTaskList(taskList);
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
