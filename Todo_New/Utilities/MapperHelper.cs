using AutoMapper;
using Data_Access.Data;
using DTOS.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Utilities
{
    public class MapperHelper
    {
        public TaskDTO TaskToTaskDTO(Task task)
        {
            return Mapper.Map<TaskDTO>(task);
        }

        public Task taskDTOToTask(TaskDTO taskDTO)
        {
            return Mapper.Map<Task>(taskDTO);
        }

        public UserDTO userToUserDTO(User user)
        {
            return Mapper.Map<UserDTO>(user);
        }

        public User userDTOToUser(UserDTO userDTO)
        {
            return Mapper.Map<User>(userDTO);
        }

        public static void MappingInit()
        {
            Object mapperTaskToTaskDTO = Mapper.CreateMap<Task, TaskDTO>();
            Object mapperTaskDTOToTask = Mapper.CreateMap<TaskDTO, Task>();
            Object mapperUserToUserDTO = Mapper.CreateMap<User, UserDTO>();
            Object mapperUserDTOToUser = Mapper.CreateMap<UserDTO, User>();
            Mapper.AssertConfigurationIsValid();
        }

    }
}