using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        ApplicationDbContext dbContext = new();
        public void Delete(int id)
        {
            var oldDepartment = GetById(id);
            dbContext.Departments.Remove(oldDepartment);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Department NewDepartmentVersion)
        {
            var oldDepartment = GetById(id);
            oldDepartment.Name = NewDepartmentVersion.Name;
            oldDepartment.Manager = NewDepartmentVersion.Manager;
            dbContext.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return dbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            return dbContext.Departments.FirstOrDefault(dep => dep.Id == id);
        }

        public void Insert(Department NewDepartment)
        {
            dbContext.Departments.Add(NewDepartment);
            dbContext.SaveChanges();
        }
    }
}
