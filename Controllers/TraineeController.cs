using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;
using Task_2ITI.Repository;

namespace Task_2ITI.Controllers
{
    [Authorize]
    public class TraineeController : Controller
    {
        ApplicationDbContext dbContext = new();
        ITraineeRepository traineeRepository;
        IDepartmentRepository departmentRepository;
        public TraineeController(ITraineeRepository _traineeRepository,IDepartmentRepository _departmentRepository)
        {
            traineeRepository = _traineeRepository;
            departmentRepository = _departmentRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Department = departmentRepository.GetAll();
            return View(traineeRepository.GetAll());
        }
         public IActionResult AddNew()
            {
                ViewBag.Department = dbContext.Departments.AsNoTracking().ToList();
                return View("AddNew");
            }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddNew(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                traineeRepository.Insert(trainee);
                return RedirectToAction("Index");
            }
            ViewBag.Department = dbContext.Departments.ToList();
            return View("AddNew", trainee);

        }
        public IActionResult Edit(int id)
        {
            ViewBag.Department = departmentRepository.GetAll();
            var Traine = traineeRepository.GetById(id);
            return View("Edit", Traine);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Trainee trainee)
        {
            if(ModelState.IsValid&&dbContext.Trainees.Any(tra=>tra.Id==id))
            {
                traineeRepository.Edit(id, trainee);
                return RedirectToAction("Index");
            }
            ViewBag.Department = departmentRepository.GetAll();
            return View(trainee);
            
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Department = departmentRepository.GetAll();
            var deletedOne = traineeRepository.GetById(id);
            return View("Delete",deletedOne);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id ,Trainee oldTrainee)
        {
            if (dbContext.Trainees.Any(tra => tra.Id == id))
                {
                traineeRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        public IActionResult details(int id)
        {
            if (dbContext.Trainees.Any(tra => tra.Id == id))
            {
                var trainee = traineeRepository.GetById(id);
                ViewBag.Department = departmentRepository.GetAll();
                return View("details", trainee) ;
            }
            ViewBag.Department = departmentRepository.GetAll();
            return View("Index",traineeRepository.GetAll());
        }

    }
}
