using AutoMapper;
using Data_Access.Data;
using Repositories.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Todo_New
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Object mapperTaskToTaskDTO = Mapper.CreateMap<Task, TaskDTO>();
            Object mapperTaskDTOToTask = Mapper.CreateMap<TaskDTO, Task>();
            Object mapperUserToUserDTO = Mapper.CreateMap<User, UserDTO>();
            Object mapperUserDTOToUser = Mapper.CreateMap<UserDTO, User>();
            Mapper.AssertConfigurationIsValid();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
