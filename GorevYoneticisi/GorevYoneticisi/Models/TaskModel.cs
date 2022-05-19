using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorevYoneticisi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
