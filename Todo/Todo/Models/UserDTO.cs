using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}