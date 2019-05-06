using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2010100009_Web.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDepartmentAdmin { get; set; }
    }
}
