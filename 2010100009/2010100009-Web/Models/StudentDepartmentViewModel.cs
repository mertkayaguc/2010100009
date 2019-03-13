using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2010100009_Web.Models
{
    public class StudentDepartmentViewModel
    {
        public Student Student { get; set; } = new Student();
        public string Department { get; set; }
        public List<Department> Departments { get; set; }
    }
}
