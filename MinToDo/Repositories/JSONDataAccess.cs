using MinToDo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinToDo.Repositories
{
    public class JSONDataAccess
    {
        private string path;
        private string jsonString = "{}";

        private List<TaskList> tasks;
        public JSONDataAccess()
        {
            path = ConfigurationManager.AppSettings["JsonDBPath"];

            ValidateFile();
            Load();
            
        }


        public List<TaskList>? Load()
        {
            tasks = JsonSerializer.Deserialize<List<TaskList>>(jsonString);
            return null;

        }

        public void Save()
        {
            List<TaskList> test = new List<TaskList>();
            test.Add(new TaskList(0, "aaa"));
            string jsonString = JsonSerializer.Serialize(test);
            File.WriteAllText(path!, jsonString);

        }

        private string JsonString()
        {
            
            

            return jsonString;
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
