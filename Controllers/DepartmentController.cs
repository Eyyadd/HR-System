using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task_2ITI.Models;
using Task_2ITI.Repository;

namespace Task_2ITI.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        IDepartmentRepository departmentRepository;
        ApplicationDbContext dbContext = new ApplicationDbContext();
        public DepartmentController(IDepartmentRepository _departmentRepository)
        {
            departmentRepository = _departmentRepository;
        }
        public IActionResult Index()
        {
            return View("Index", departmentRepository.GetAll());
        }
        public IActionResult details(int id)
        {
            if(dbContext.Departments.Any(dep=>dep.Id==id))
            {
                return View("details", departmentRepository.GetById(id));
            }
            return View("Index",departmentRepository.GetAll());
        }
        public IActionResult Edit(int id)
        {
            var oldDepartment = departmentRepository.GetById(id);
            return View("Edit",oldDepartment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Department department)
        {
           
            if (ModelState.IsValid)
            {
                departmentRepository.Edit(id, department);
                return RedirectToAction("Index");
            }
            else
                return View(department);
          
        }
        public IActionResult Delete(int id)
        {
            var oldDepartment = departmentRepository.GetById(id);
            return View("Delete", oldDepartment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Department oldDepartment)
        {
            if (dbContext.Departments.Any(dep => dep.Id == id))
            {
                departmentRepository.Delete(id);
                return RedirectToAction("Index");
            }
            else
                return View("Index");
        }
        public IActionResult AddNew()
        {
            return View("AddNew");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Department department)
        {
            if (ModelState.IsValid)
            {
                departmentRepository.Insert(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }
    }
}
