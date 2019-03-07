using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2010100009_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace _2010100009_Web.Controllers
{
    public class StudentsController : Controller
    {
        StudentDBContext StudentDBContext;

        public StudentsController(StudentDBContext context)
        {
            StudentDBContext = context;
        }

        public IActionResult Index()
        {
            var students = StudentDBContext.Students.ToList();
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            Student student = StudentDBContext.Students.Where(stu => stu.Id == id).FirstOrDefault();

            if (student != null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            StudentDBContext.Students.Add(student);
            StudentDBContext.SaveChanges();

            if (student != null)
            {
                var students = StudentDBContext.Students.ToList();
                return View("Index", students);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(int id)
        {
            Student student = StudentDBContext.Students.Where(stu => stu.Id == id).FirstOrDefault();

            if (student != null)
            {
                return View(student);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var currentUser = StudentDBContext.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            currentUser.Department = student.Department;
            currentUser.Name = student.Name;
            currentUser.StuID = student.StuID;

            StudentDBContext.SaveChanges();

            if (student != null)
            {
                var students = StudentDBContext.Students.ToList();
                return View("Index", students);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
