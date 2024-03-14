using MinToDo.Models;
using MinToDo.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MinToDo.Controllers
{
    public class TaskListController
    {
        private readonly TaskListRepository Repository;
        public TaskListController()
        {
            Repository = new();
        }
        public List<TaskList> GetTaskLists()
        {
            return Repository.GetTaskLists();
        }
        public void AddTaskList(string title)
        {
            TaskList newList = new(title);

            Repository.AddTaskList(newList);
        }
        public void RemoveTaskList(string title)
        {
            TaskList? taskList = GetTaskLists().FirstOrDefault(taskList => taskList.Title == title);
            if (taskList != null)
                Repository?.RemoveTaskList(taskList);
        }
        public void AddTask(TaskList taskList, string title)
        {
            Task newTask = new(title);
            Repository.AddTask(taskList, newTask);
        }
        public void RemoveTask(TaskList taskList, string title)
        {
            Task? task = taskList.Tasks.FirstOrDefault(task => task.Title == title);
            if (task != null)
                Repository?.RemoveTask(taskList, task);
        }


    }
}