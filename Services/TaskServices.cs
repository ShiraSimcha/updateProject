using cores.Models;
using System.Collections.Generic;
using System.Linq;

namespace cores.Controllers
{   
    public static class TaskServices
    {    
        private static List<Assiment> Tasks = new List<Assiment>
        {
            new Assiment {Id=1, Name="dishes", Description = "Washing the Dishes",Deadline=new DateTime(2023,2,3), Done=false},
            new Assiment {Id=2, Name="praying", Description = "To pray mincha",Deadline=new DateTime(2023,1,3), Done=false},
            new Assiment {Id=3, Name="homwork", Description = "To do homwork at cores",Deadline=new DateTime(2023,1,3), Done=false},
            new Assiment {Id=4, Name="test", Description = "To learn to the test in java",Deadline=new DateTime(2023,1,3), Done=false}
            };


        public static List<Assiment> GetAll() => Tasks;
        public static Assiment Get(int id)
        {
            return Tasks.FirstOrDefault(p => p.Id == id);
        }

        public static bool Update(int id, Assiment newTask)
        {
            if (newTask.Id != id)
                return false;
            
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            task.Name = newTask.Name;
            task.Description = newTask.Description;
            task.Done=newTask.Done;
            task.Deadline=newTask.Deadline;
            return true;
        }

        public static bool Delete(int id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
                return false;
            Tasks.Remove(task);
            return true;
        }
         public static void Add(Assiment assiment)
        {
            assiment.Id = Tasks.Max(p => p.Id) + 1;
            Tasks.Add(assiment);
        }

        }

    }
