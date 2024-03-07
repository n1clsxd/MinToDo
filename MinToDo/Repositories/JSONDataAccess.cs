using MinToDo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace MinToDo.Repositories
{
    public class JsonDataAccess
    {
        private readonly string? path;
        private List<TaskList> taskLists;


        public JsonDataAccess()
        {
            path = ConfigurationManager.AppSettings["JsonData"];   
            taskLists = new List<TaskList>();
            InitializeTaskLists();
        }

        public void InitializeTaskLists()
        {
            List<TaskList>? deserializedJson;
            try
            {
                if (path is null)
                {
                    deserializedJson = new List<TaskList>() { TaskList.Default };
                }
                else
                {
                    string jsonString = GetJsonString(path);
                    JsonDocument jsonDocument = GetParsedJson(jsonString);
                    deserializedJson = JsonSerializer.Deserialize<List<TaskList>>(jsonDocument);
                    taskLists = deserializedJson!;
                }
            }
            catch (Exception)
            {
                taskLists = new List<TaskList>() { TaskList.Default };
            }
        }
        public List<TaskList> GetLists()
        {
            return taskLists;
        }
        public void AddList(TaskList taskList) => taskLists.Add(taskList);
        public void RemoveList(TaskList taskList) => taskLists.Remove(taskList);
        public void AddTask(TaskList taskList, Task task) => taskList.Tasks.Add(task);
        public void RemoveTask(TaskList tasklist, Task task) => tasklist.Tasks.Remove(task);
        public void Persist() => File.WriteAllText(path, JsonSerializer.Serialize(taskLists));
        private static string GetJsonString(string path)
        {
            if (!File.Exists(path!))
            {
                File.WriteAllText(path!, JsonSerializer.Serialize(new List<TaskList>() { TaskList.Default }));
            }
            return File.ReadAllText(path!);
        }
        private static JsonDocument GetParsedJson(string json)
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
