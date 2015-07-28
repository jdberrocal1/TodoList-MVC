using AutoMapper;
using Data_Access.Data;
using Repositories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Repositories
{
    public class UserRepository
    {
        private TodoList db = new TodoList();

        public List<UserDTO> getAll()
        {
            var users = new List<UserDTO>();

            foreach (User user in db.Users.ToList())
            {
                //UserDTO dto = Mapper.Map<UserDTO>(user);

                UserDTO dto = new UserDTO();
                dto.UserName = user.UserName;
                dto.UserId = user.UserId;
                dto.UserEmail = user.UserEmail;

                users.Add(dto);
            }

            return users;
        }


        public void Create(UserDTO userDTO)
        {

            User user = new User();
            user.UserName = userDTO.UserName;
            user.UserId = userDTO.UserId;
            user.UserEmail = userDTO.UserEmail;

            db.Users.Add(user);
            db.SaveChanges();
        }

        public UserDTO getUserID(int? id)
        {
            User user = db.Users.Find(id);

            UserDTO dto = new UserDTO();
            dto.UserName = user.UserName;
            dto.UserId = user.UserId;
            dto.UserEmail = user.UserEmail;
            return dto;
        }
    }
}