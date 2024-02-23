using MinToDo.Controllers;
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
        public TaskListController TaskListController { get; set; }



        public ToDoListPage()
        {
            TaskListController = new TaskListController();
            DataContext = TaskListController;
            InitializeComponent();
            
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
            if (NewTaskTextBox.Text == string.Empty) return;


            //TaskList.Items.Add(NewTaskTextBox.Text);
            TaskListController.AddTask(TaskListController.CurrentTaskList, NewTaskTextBox.Text);

            NewTaskTextBox.Text = string.Empty;
            NewTaskTextBox.Focus();
           
        }
        private void AddTaskListButton_Click(Object sender, RoutedEventArgs e)
        {
            TaskListController.AddTaskList("ababa");
        }
        

        private void MarkTaskAsDoneButton_Click(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            TextBlock textBlock = (TextBlock)((DockPanel)button.Parent).FindName("taskTextBlock");
            if(button != null)
            {
                string str = textBlock.Text;

                //TaskList.Items.Remove(item);
                TaskListController.RemoveTask(textBlock.Text);
            }

        }
    }
}
