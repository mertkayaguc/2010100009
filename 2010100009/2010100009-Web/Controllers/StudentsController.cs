using System;
using System.IO;
using System.Linq;
using _2010100009_Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace _2010100009_Web.Controllers
{
    public class StudentsController : Controller
    {
        StudentDBContext StudentDBContext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public StudentsController(StudentDBContext context, IHostingEnvironment hostingEnvironment)
        {
            StudentDBContext = context;
            _hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create(StudentDepartmentViewModel studentDepartmentViewModel, IFormFile photoFile)
        {
            studentDepartmentViewModel.Student.Department = studentDepartmentViewModel.Department;

            if (studentDepartmentViewModel.Student != null)
            {
                var students = StudentDBContext.Students.ToList();

                if (photoFile != null)
                {
                    string dirPath = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + photoFile.FileName;
                    using (var fileStream = new FileStream(dirPath + fileName, FileMode.Create))
                    {
                        await photoFile.CopyToAsync(fileStream);
                    }

                    studentDepartmentViewModel.Student.ImageUrl = fileName;
                }

                StudentDBContext.Students.Add(studentDepartmentViewModel.Student);
                StudentDBContext.SaveChanges();

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
        public async Task<IActionResult> Edit(StudentDepartmentViewModel studentDepartmentViewModel, int id, IFormFile photoFile)
        {
            var currentUser = StudentDBContext.Students.Where(x => x.Id == id).FirstOrDefault();
            currentUser.Department = studentDepartmentViewModel.Department;
            currentUser.Name = studentDepartmentViewModel.Student.Name;
            currentUser.StuID = studentDepartmentViewModel.Student.StuID;
            currentUser.Description = studentDepartmentViewModel.Student.Description;

            if (studentDepartmentViewModel.Student != null)
            {
                var students = StudentDBContext.Students.ToList();

                if (photoFile != null)
                {
                    string dirPath = Path.Combine(_hostingEnvironment.WebRootPath, @"uploads\");
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + "_" + photoFile.FileName;
                    using (var fileStream = new FileStream(dirPath + fileName, FileMode.Create))
                    {
                        await photoFile.CopyToAsync(fileStream);
                    }

                    currentUser.ImageUrl = fileName;
                }


                StudentDBContext.Update(currentUser);
                StudentDBContext.SaveChanges();

                return View("Index", students);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
