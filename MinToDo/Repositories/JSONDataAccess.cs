using MinToDo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MinToDo.Repositories
{
    public class JSONDataAccess
    {
        private string path;
        private string jsonString = "{}";

        private List<TaskList> taskLists;
        public JSONDataAccess()
        {
            path = ConfigurationManager.AppSettings["JsonDBPath"];

            ValidateFile();
            Load();
            
        }


        public void Load()
        {

            taskLists = JsonSerializer.Deserialize<List<TaskList>>(jsonString!);
            

        }
        public List<TaskList> GetLists()
        {
            return taskLists;
        }


        public void AddList(TaskList taskList)
        {
            taskLists.Add(taskList);
        }
        public void RemoveList(TaskList taskList)
        {
            taskLists.Remove(taskList);
        }

        public void AddTask(TaskList taskList, Task task)
        {
           taskList.Tasks.Add(task);
        }

        public void RemoveTask(TaskList tasklist, Task task)
        {
            tasklist.Tasks.Remove(task);
        }


        public void Save()
        {
            string newString = JsonSerializer.Serialize(taskLists);

            File.WriteAllText(path!, newString);

        }

       

        private void ValidateFile()
        {
            if (File.Exists(path))
            {
                jsonString = File.ReadAllText(path);
            }
            else
            {
                File.CreateText(path!).Dispose();
                File.WriteAllText(path!, JsonSerializer.Serialize(new List<TaskList>()));
            }
        }
    }
}
