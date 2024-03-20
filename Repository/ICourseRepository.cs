using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll();
        Course GetById(int id);
        void Insert(Course NewCourse);
        void Edit(int id, Course NewCourseVersion);
        void Delete(int id);
    }
}