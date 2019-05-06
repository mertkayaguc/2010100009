using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2010100009_Web.Models
{
    public class WebUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string StudentID { get; set; }

        [Required]
        [StringLength(100)]
        public string City { get; set; }

        [Required]
        public int DepartmentID { get; set; }
    }
}
