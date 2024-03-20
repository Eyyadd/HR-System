using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        ApplicationDbContext dbContext = new();
        public void Delete(int id)
        {
            var oldInstructor = GetById(id);
            dbContext.Instructors.Remove(oldInstructor);
        }

        public void Edit(int id, Instructor NewInstructorVersion)
        {
            var oldInstructor = GetById(id);
            oldInstructor.Name = NewInstructorVersion.Name;
            oldInstructor.Image = NewInstructorVersion.Image;
            oldInstructor.Salary = NewInstructorVersion.Salary;
            oldInstructor.Address = NewInstructorVersion.Address;
            oldInstructor.CourseId = NewInstructorVersion.CourseId;
            oldInstructor.DepID = NewInstructorVersion.DepID;

            dbContext.SaveChanges();
        }

        public List<Instructor> GetAll()
        {
            return dbContext.Instructors.AsNoTracking().ToList(); 
        }

        public Instructor GetById(int id)
        {
            return dbContext.Instructors.FirstOrDefault(ins => ins.Id == id);
        }

        public void Insert(Instructor NewInstructor)
        {
            dbContext.Instructors.Add(NewInstructor);
            dbContext.SaveChanges();
        }
    }
}
