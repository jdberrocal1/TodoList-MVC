using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access.Data;
using System.Data.Entity;
using Utilities;
using DTOS.DTOS;

namespace Repositories.Repositories
{
    public class TaskRepository
    {
        private TodoList db = new TodoList();
        private UserRepository userRepo = new UserRepository();
        private MapperHelper mapper = new MapperHelper();      

        public List<TaskDTO> GetAll()
        {
            var tasks = new List<TaskDTO>();
            foreach (Task task in db.Tasks.ToList())
            {
                tasks.Add(mapper.TaskToTaskDTO(task));
            }
            
            return tasks;
        }

        public TaskDTO GetTaskID(int? id)
        {
            TaskDTO task = mapper.TaskToTaskDTO( db.Tasks.Find(id));
            return task;
        }

        public void Create(TaskDTO taskDTO)
        {
            User user = db.Users.Find(taskDTO.User.UserId);
            Task task = mapper.taskDTOToTask(taskDTO);
            task.User = user;           
            db.Tasks.Add(task);
            db.SaveChanges();
        }


        public void EditTask(TaskDTO taskDTO)
        {
            User user = db.Users.Find(taskDTO.User.UserId);
            Task task = mapper.taskDTOToTask(taskDTO);
            task.User = user;
            task.UserId = user.UserId;
            db.Entry(task).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteTask(int? id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
        }
    }
}