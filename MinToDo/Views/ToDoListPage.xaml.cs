﻿using MinToDo.Controllers;
using MinToDo.Models;
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
            TaskListViewModel = new TaskListViewModel();
            DataContext = TaskListViewModel;
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
        private void TaskListsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            TaskListViewModel.UpdateCurrentTaskList(listBox.SelectedItem?.ToString());

        }

        private void RemoveTaskList_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            ContextMenu = (ContextMenu)menuItem.Parent;

            ListBox listBox = (ListBox)ContextMenu.PlacementTarget;
            TaskListViewModel.RemoveTaskList(listBox.SelectedItem.ToString());
        }
    }
}
