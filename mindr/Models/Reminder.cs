using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mindr.Models
{
    class Reminder
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Due { get; set; }
    }
}
