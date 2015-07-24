using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Todo.Models
{
    public class Task
    {
        public int TodoId { get; set; }
        //[Required]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        //[Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}