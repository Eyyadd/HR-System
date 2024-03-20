using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;
using Task_2ITI.Repository;

namespace Task_2ITI.Controllers
{
    [Authorize]
    public class InstructorController : Controller
    {
        ApplicationDbContext dbContext = new();
        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;
        ICourseRepository courseRepository;
        public InstructorController(IInstructorRepository _instructorRepository,IDepartmentRepository _departmentRepository,ICourseRepository _courseRepository)
        {
            instructorRepository = _instructorRepository;
            departmentRepository = _departmentRepository;
            courseRepository = _courseRepository;
        }
        public IActionResult CheckCity(string Address)
        {
            if(Address.ToLower()=="cairo")
            {
                return Json(true);
            }
            return Json(false);
        }
        public IActionResult Index()
        {
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = courseRepository.GetAll();
            return View("Index",instructorRepository.GetAll());
        }
        public IActionResult AddNew()
        {
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = courseRepository.GetAll();
            return View("AddNew");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Instructor instructor) 
        {
            if (ModelState.IsValid)
            {
                instructorRepository.Insert(instructor);
                return RedirectToAction("Index");
            }
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = courseRepository.GetAll();
            return View(instructor);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = courseRepository.GetAll();
            return View("Edit", instructorRepository.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Instructor NewInstructor)
        {
            if (ModelState.IsValid && dbContext.Instructors.Any(ins=>ins.Id==id) )
            {
                instructorRepository.Edit(id,NewInstructor);
                return RedirectToAction("Index");
            }
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = courseRepository.GetAll();
            return View("Edit", instructorRepository.GetAll());
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Department = departmentRepository.GetAll();
            ViewBag.Courses = departmentRepository.GetAll();
            var Ins = instructorRepository.GetById(id);
            return View("Delete",Ins);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Instructor oldIns)
        {
            if (dbContext.Instructors.Any(ins => ins.Id == id))
            {
                instructorRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult details(int id)
        {
            if (dbContext.Instructors.Any(ins => ins.Id == id))
            {
                ViewBag.Department = departmentRepository.GetAll();
                ViewBag.Courses = courseRepository.GetAll();
                return View("details",instructorRepository.GetById(id));
            }
            return RedirectToAction("Index");
        }
    }
}
