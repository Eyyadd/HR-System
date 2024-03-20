using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        ApplicationDbContext dbContext = new();
        public void Delete(int id)
        {
            var oldCourse = GetById(id);
            dbContext.Courses.Remove(oldCourse);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Course NewCourseVersion)
        {
            var oldCourse = GetById(id);
            oldCourse.Name = NewCourseVersion.Name;
            oldCourse.MinDegree = NewCourseVersion.MinDegree;
            oldCourse.Degree = NewCourseVersion.Degree;
            oldCourse.DepId = NewCourseVersion.DepId;

            dbContext.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return dbContext.Courses.AsNoTracking().ToList();
        }

        public Course GetById(int id)
        {
          return dbContext.Courses.FirstOrDefault(crs => crs.Id == id);
        }

        public void Insert(Course NewCourse)
        {
            dbContext.Courses.Add(NewCourse);
            dbContext.SaveChanges();
        }
    }
}
