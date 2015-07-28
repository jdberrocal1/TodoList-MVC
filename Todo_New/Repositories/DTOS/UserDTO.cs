using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.DTOS
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual ICollection<TaskDTO> Tasks { get; set; }
    }
}