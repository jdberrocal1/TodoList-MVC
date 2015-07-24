using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class User
    {
        public int UserId { get; set; }
        //[Required]
        //[Required(ErrorMessage = "Please enter The User Name")]
        //[Display(Name = "Name")]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}