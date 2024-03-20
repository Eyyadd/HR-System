using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public interface ITraineeRepository
    {
        List<Trainee> GetAll();
        Trainee GetById(int id);
        void Insert(Trainee NewTrainee);
        void Delete(int id);
        void Edit(int id, Trainee NewTraineeVersion);
    }
}