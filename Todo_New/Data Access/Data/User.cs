using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Data_Access.Data
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; }

        
        [Required]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}