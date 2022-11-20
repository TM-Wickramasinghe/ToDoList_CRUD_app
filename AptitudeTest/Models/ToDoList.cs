using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptitudeTest.Models
{
    public class ToDoList
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public DateTime Date { get; set; }
    }
}
