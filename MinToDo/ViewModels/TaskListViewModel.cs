using MinToDo.Controllers;
using MinToDo.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MinToDo.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        private TaskListController TaskListController { get; set; }

        public TaskList? CurrentTaskList;
        public ObservableCollection<string> TaskListTitles { get; set; }
        public ObservableCollection<string> CurrentTaskListTaskTitles { get; set; }

        public string? CurrentTaskListTitle => CurrentTaskList?.Title;

        public event PropertyChangedEventHandler? PropertyChanged;

        public TaskListViewModel()
        {
            TaskListController = new TaskListController();

            CurrentTaskList = new TaskList();
            TaskListTitles = new ObservableCollection<string>();
            CurrentTaskListTaskTitles = new ObservableCollection<string>();
            InitializeData(TaskListController);
        }

        public void InitializeData(TaskListController taskListController)
        {

            CurrentTaskList = taskListController.GetTaskLists().FirstOrDefault();
            TaskListTitles = new ObservableCollection<string>(TaskListController.GetTaskLists().Select(taskList => taskList.Title));
            CurrentTaskListTaskTitles = new ObservableCollection<string>(CurrentTaskList!.Tasks.Select(task => task.Title));

        }

        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void UpdateCurrentTaskList(string title)
        {
            var taskLists = TaskListController.GetTaskLists();
            CurrentTaskList = taskLists.FirstOrDefault(task => task.Title == title) ?? taskLists.First();

            OnPropertyChanged(nameof(CurrentTaskList));
            OnPropertyChanged(nameof(CurrentTaskListTitle));
            CurrentTaskListTaskTitles = new ObservableCollection<string>(CurrentTaskList!.Tasks.Select(task => task.Title));
            OnPropertyChanged(nameof(CurrentTaskListTaskTitles));
        }
        public void AddTaskList(string title = "MyList")
        {
            if (TaskListTitles.Contains(title))
            {
                for (int i = 0; i < TaskListTitles.Count; i++)
                {
                    if (!TaskListTitles.Contains(title + $"{i+1}"))
                    {
                        title += $"{i+1}";
                        break;
                    }
                }

            }
            

            TaskListController.AddTaskList(title);
            TaskListTitles.Add(title);
        }

        public void AddTask(string title = "NewTask")
        {
            TaskListController.AddTask(CurrentTaskList, title);
            CurrentTaskListTaskTitles.Add(title);
        }
        public void RemoveTask(string title)
        {
            TaskListController.RemoveTask(CurrentTaskList, title);
            CurrentTaskListTaskTitles.Remove(title);
        }

        public void RemoveTaskList(string title)
        {
            if (TaskListTitles.Count > 1)
            {
                TaskListController.RemoveTaskList(title);
                TaskListTitles.Remove(title);
            }
        }

    }
}
