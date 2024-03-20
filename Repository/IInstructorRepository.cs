using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll();
        Instructor GetById(int id);
        void Insert(Instructor NewInstructor);
        void Delete(int id);
        void Edit(int id, Instructor NewInstructorVersion);
    }
}