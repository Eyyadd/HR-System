using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAll();
        Department GetById(int id);
        void Insert(Department NewDepartment);
        void Delete(int id);
        void Edit(int id, Department NewDepartmentVersion);
        
    }
}