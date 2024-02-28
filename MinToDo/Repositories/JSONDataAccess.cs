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
    public class JsonDataAccess
    {
        private readonly string path;
        private string jsonString;
        private List<TaskList> taskLists;


        public JsonDataAccess()
        {
            path = ConfigurationManager.AppSettings["JsonDBPath"]!;
            taskLists = new List<TaskList>();
            jsonString = ValidateFile();
            Load();
        }

        public void Load()
        {
            List<TaskList>? deserializedJson;
            try
            {
                deserializedJson = JsonSerializer.Deserialize<List<TaskList>>(ValidateJson(ValidateFile()));
            }
            catch (Exception)
            {
                deserializedJson = new List<TaskList>()
                {
                    new TaskList()
                    {
                        Title = "taa",
                        Tasks = new List<Task>()
                        {
                            new Task("deu erro no json pae") { }
                        }
                    }
                };
            }
            taskLists = deserializedJson!;
        }
        public List<TaskList> GetLists()
        {
            return taskLists;
        }

        public void AddList(TaskList taskList) => taskLists.Add(taskList);
        public void RemoveList(TaskList taskList) => taskLists.Remove(taskList);
        public void AddTask(TaskList taskList, Task task) => taskList.Tasks.Add(task);
        public void RemoveTask(TaskList tasklist, Task task) => tasklist.Tasks.Remove(task);
        public void Persist() => File.WriteAllText(path!, JsonSerializer.Serialize(taskLists));

        private string ValidateFile()
        {
            if (!File.Exists(path!))
            {
                File.CreateText(path!).Dispose();
                List<TaskList> list = new()
                {
                    new TaskList("MyList")
                };
                File.WriteAllText(path!, JsonSerializer.Serialize(list));
            }
            return File.ReadAllText(path!);
        }
        private JsonDocument ValidateJson(string json)
        {
            try
            {
                return JsonDocument.Parse(json);
            }
            catch (JsonException)
            {
                return JsonDocument.Parse(string.Empty);
            }
        }
    }
}
