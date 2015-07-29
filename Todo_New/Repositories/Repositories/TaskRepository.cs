using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access.Data;
using Repositories.DTOS;
using AutoMapper;
using System.Data.Entity;

namespace Repositories.Repositories
{
    public class TaskRepository
    {
        private TodoList db = new TodoList();
               
        public TaskDTO TaskToTaskDTO(Task task)
        {
            return Mapper.Map<TaskDTO>(task);
        }

        public Task taskDTOToTask(TaskDTO taskDTO)
        {
            return Mapper.Map<Task>(taskDTO);
        }

        public List<TaskDTO> getAll()
        {
            var tasks = new List<TaskDTO>();

            foreach (Task task in db.Tasks.ToList())
            {
                tasks.Add(TaskToTaskDTO(task));
            }
            
            return tasks;
        }

        public TaskDTO getTaskID(int? id)
        {
            TaskDTO task = TaskToTaskDTO( db.Tasks.Find(id));

            return task;
        }

        public void Create(TaskDTO taskDTO)
        {
            User user = db.Users.Find(taskDTO.User.UserId);
            Task task = taskDTOToTask(taskDTO);
            task.User = user;           

            db.Tasks.Add(task);
            db.SaveChanges();
        }


        public void editTask(TaskDTO taskDTO)
        {
            db.Entry(taskDTOToTask(taskDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteTask(int? id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
        }
    }
}