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
            StudentDepartmentViewModel mode = new StudentDepartmentViewModel();
            mode.Departments = StudentDBContext.Departments.ToList();
            return View(mode);
        }

        [HttpPost]
        public IActionResult Create(StudentDepartmentViewModel studentDepartmentViewModel)
        {
            studentDepartmentViewModel.Student.Department = studentDepartmentViewModel.Department;
            StudentDBContext.Students.Add(studentDepartmentViewModel.Student);
            StudentDBContext.SaveChanges();

            if (studentDepartmentViewModel.Student != null)
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
            StudentDepartmentViewModel studentDepartmentViewModel = new StudentDepartmentViewModel();

            studentDepartmentViewModel.Student = student;
            studentDepartmentViewModel.Departments = StudentDBContext.Departments.ToList();

            if (student != null)
            {
                return View(studentDepartmentViewModel);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Edit(StudentDepartmentViewModel studentDepartmentViewModel, int id)
        {
            var currentUser = StudentDBContext.Students.Where(x => x.Id == id).FirstOrDefault();
            currentUser.Department = studentDepartmentViewModel.Department;
            currentUser.Name = studentDepartmentViewModel.Student.Name;
            currentUser.StuID = studentDepartmentViewModel.Student.StuID;

            StudentDBContext.SaveChanges();

            if (studentDepartmentViewModel.Student != null)
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
