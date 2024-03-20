using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Task_2ITI.Models;
using Task_2ITI.Repository;

namespace Task_2ITI.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
      
        ApplicationDbContext dbContext = new ApplicationDbContext();
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository _courseRepository,IDepartmentRepository _departmentRepository)
        {
            courseRepository = _courseRepository;
            departmentRepository = _departmentRepository;
        }

        public IActionResult CheckMinimumDegree(int MinDegree, int Degree)
        {
            if (MinDegree > Degree)
            {
                return Json(false);
            }
            else
                return Json(true);
        }
        public IActionResult Index()
        {
            ViewBag.Department = departmentRepository.GetAll();
            return View("Index", courseRepository.GetAll());
        }

        public IActionResult details(int id)
        {
            if (dbContext.Courses.Any(crs => crs.Id == id))
            {
                var course = courseRepository.GetById(id);
                ViewBag.Department = dbContext.Departments.Where(dep => dep.Id == course.DepId).ToList();
                return View("details",course);
            }
            else
            {
                ModelState.AddModelError("Id", "The Id is Not Found");
            }
            ViewBag.Department = departmentRepository.GetAll();
            return View("Index",courseRepository.GetAll());
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Department = departmentRepository.GetAll();
            return View("Edit", courseRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Course course)
        {
            
            if (ModelState.IsValid)
            {
                courseRepository.Edit(id, course);
                return RedirectToAction("Index");
            }
            ViewBag.Department = departmentRepository.GetAll();
            return View(course);

        }

        public IActionResult Delete(int id)
        {
            var DeletedCourse= courseRepository.GetById(id);
            ViewBag.Department = departmentRepository.GetAll();
            return View("Delete",DeletedCourse);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id,Course oldCourse)
        {
            courseRepository.Delete(Id);
                return RedirectToAction("Index");
        }
        public IActionResult Addnew()
        {
            ViewBag.Departments = departmentRepository.GetAll();
            return View("Addnew");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Addnew(Course newCourse)
        {
            if (ModelState.IsValid)
            {
                courseRepository.Insert(newCourse);
                return RedirectToAction("Index");
            }
            ViewBag.Departments = departmentRepository.GetAll();
            return View(newCourse);
        }
    }
}
