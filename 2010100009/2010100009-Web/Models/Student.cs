using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2010100009_Web.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public long StuID { get; set; }

        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
