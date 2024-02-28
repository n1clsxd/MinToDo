using MinToDo.Models;
using MinToDo.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MinToDo.Controllers
{
    public class TaskListController: INotifyPropertyChanged
    {
        private TaskListRepository TaskListRepository { get; }
        public TaskList? CurrentTaskList;
        public string CurrentTaskListTitle { get; set; }

        public TaskListController()
        {
            TaskListRepository = new();
            CurrentTaskList = TaskListRepository.GetLists().FirstOrDefault();

            TaskListTitles = new ObservableCollection<string>(TaskListRepository.GetLists().Select(taskList => taskList.Title));

            CurrentTaskListTaskTitles = new ObservableCollection<string>(CurrentTaskList.Tasks.Select(task => task.Title));
            UpdateCurrentTaskListTaskTitles(CurrentTaskList);
        }

        public ObservableCollection <string>? TaskListTitles {  get; set; }
        public ObservableCollection <string>? CurrentTaskListTaskTitles { get; set; }

        public void AddTaskList(string title)
        {
            TaskList newList = new(title);
            TaskListRepository.AddList(newList);
            TaskListTitles.Add(newList.Title);

            OnPropertyChanged(nameof(TaskListTitles));
        }

        public void AddTask(TaskList taskList, string title)
        {
            Task newTask = new(title);
            TaskListRepository.AddTask(taskList, newTask);
            UpdateCurrentTaskListTaskTitles(taskList);
            CurrentTaskListTaskTitles.Add(newTask.Title);
            OnPropertyChanged(nameof(CurrentTaskListTaskTitles));
            
        }

        public void RemoveTask(string title)
        {
            //CurrentTaskList.Tasks.Remove();
            TaskListRepository?.RemoveTask(CurrentTaskList, CurrentTaskList.Tasks.FirstOrDefault(task => task.Title == title));
            CurrentTaskListTaskTitles.Remove(title);
            OnPropertyChanged(nameof(CurrentTaskListTaskTitles));
        }



        public void UpdateCurrentTaskListTaskTitles(TaskList currentList)
        {
            CurrentTaskListTitle = currentList.Title;
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
