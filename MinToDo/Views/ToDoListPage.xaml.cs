using MinToDo.Controllers;
using MinToDo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinToDo
{
    /// <summary>
    /// Interação lógica para test.xam
    /// </summary>
    public partial class ToDoListPage : Page
    {
        TaskListViewModel TaskListViewModel { get; set; }

        public ToDoListPage()
        {
            InitializeComponent();
            TaskListViewModel = new TaskListViewModel();
            DataContext = TaskListViewModel;
            
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e) => AddTask();
        private void NewTaskTextBox_KeyDown(object sender, KeyEventArgs e) 
        {
            if(e.Key == Key.Enter)
            {
                AddTask();
            }
        }

        private void AddTask()
        {
            if (NewTaskTextBox.Text != string.Empty)
            {
                TaskListViewModel.AddTask(NewTaskTextBox.Text);

                NewTaskTextBox.Text = string.Empty;
                NewTaskTextBox.Focus();
            }
        }

        private void AddTaskListButton_Click(Object sender, RoutedEventArgs e)
        {
            TaskListViewModel.AddTaskList();
        }
        
        private void MarkTaskAsDoneButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TextBlock textBlock = (TextBlock)((DockPanel)button.Parent).FindName("taskTextBlock");
            if(button != null)
            {
                TaskListViewModel.RemoveTask(textBlock.Text);
            }

        }
    }
}
