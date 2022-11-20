using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AptitudeTest.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string? StatusMessage { get; set; }
        public ToDoList? ToDoList { get; set; }
        public List<ToDoList>? listToDoList { get; set;}
    }
}
