using AutoMapper;
using Data_Access.Data;
using Repositories.DTOS;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repositories.Repositories
{
    public class UserRepository
    {
        private TodoList db = new TodoList();
        
        public UserDTO userToUserDTO(User user)
        {
            return Mapper.Map<UserDTO>(user);
        }

        public User userDTOToUser(UserDTO userDTO)
        {
            return Mapper.Map<User>(userDTO);
        }

        public List<UserDTO> getAll()
        {
            var users = new List<UserDTO>();
            foreach (User user in db.Users.ToList())
            {
                UserDTO dto = userToUserDTO(user);
                users.Add(dto);
            }
            return users;
        }

        public UserDTO getUserID(int? id)
        {
            User user = db.Users.Find(id);
            return userToUserDTO(user);
        }


        public void Create(UserDTO userDTO)
        {
            db.Users.Add(userDTOToUser(userDTO));
            db.SaveChanges();
        }

        

        public void editUser(UserDTO userDTO)
        {
            db.Entry(userDTOToUser(userDTO)).State = EntityState.Modified;
            db.SaveChanges();

        }

        public void deleteUser(int? id)
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