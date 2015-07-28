using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data_Access.Data;
using Repositories.DTOS;
using AutoMapper;

namespace Repositories.Repositories
{
    public class TaskRepository
    {
        private TodoList db = new TodoList();
        

        public List<TaskDTO> getAll()
        {
            var tasks = new List<TaskDTO>();

            foreach (Task task in db.Tasks.ToList())
            {
                TaskDTO dto = Mapper.Map<TaskDTO>(task);
                tasks.Add(dto);
            }
            
            return tasks;
        }

        public void Create(TaskDTO taskDTO)
        {
            /*var userDTO = taskDTO.User;
            taskDTO.User = Mapper.Map<UserDTO>(userDTO);
            Task task = Mapper.Map<Task>(taskDTO);*/
            /*User user = new User();
            user.UserEmail = taskDTO.User.UserEmail;
            user.UserId = taskDTO.User.UserId;
            user.UserName = taskDTO.User.UserName;
            */
            Task task = new Task();
            task.User = null;
            task.Date = taskDTO.Date;
            task.Description = taskDTO.Description;
            

            db.Tasks.Add(task);
            db.SaveChanges();
        }
    }
}