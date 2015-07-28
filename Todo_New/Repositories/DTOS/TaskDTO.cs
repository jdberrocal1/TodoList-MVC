using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.DTOS
{
    public class TaskDTO
    {
        public int TodoId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public virtual UserDTO User { get; set; }
    }
}