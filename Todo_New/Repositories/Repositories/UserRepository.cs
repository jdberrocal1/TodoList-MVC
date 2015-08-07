using Data_Access.Data;
using DTOS.DTOS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Utilities;

namespace Repositories.Repositories
{
    public class UserRepository
    {
        private TodoList db = new TodoList();
        private MapperHelper mapper = new MapperHelper(); 

        public List<UserDTO> GetAll()
        {
            var users = new List<UserDTO>();
            foreach (User user in db.Users.ToList())
            {
                UserDTO dto = mapper.userToUserDTO(user);
                users.Add(dto);
            }
            return users;
        }

        public UserDTO GetUserID(int? id)
        {
            User user = db.Users.Find(id);
            return mapper.userToUserDTO(user);
        }


        public void Create(UserDTO userDTO)
        {
            db.Users.Add(mapper.userDTOToUser(userDTO));
            db.SaveChanges();
        }

        

        public void EditUser(UserDTO userDTO)
        {
            db.Entry(mapper.userDTOToUser(userDTO)).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void DeleteUser(int? id)
        {
            
            foreach (Task task in db.Tasks.ToList())
            {
                if (task.User.UserId == id)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                }
            }
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();

        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}