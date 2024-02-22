using MinToDo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinToDo.Controllers
{
    public class TaskListController
    {
        public JSONDataAccess access;

        public TaskListController()
        {
            JSONDataAccess access = new JSONDataAccess();

        }

        
    }
}
