using Microsoft.EntityFrameworkCore;
using Task_2ITI.Models;

namespace Task_2ITI.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        ApplicationDbContext dbContext = new();
        public void Delete(int id)
        {
            var oldTrainee = GetById(id);
            dbContext.Trainees.Remove(oldTrainee);
            dbContext.SaveChanges();
        }

        public void Edit(int id, Trainee NewTraineeVersion)
        {
            var oldTrainee = GetById(id);
            oldTrainee.Name = NewTraineeVersion.Name;
            oldTrainee.Image = NewTraineeVersion.Image;
            oldTrainee.Address = NewTraineeVersion.Address;
            oldTrainee.Grade = NewTraineeVersion.Grade;
            oldTrainee.DepID = NewTraineeVersion.DepID;

            dbContext.SaveChanges();
        }

        public List<Trainee> GetAll()
        {
            return dbContext.Trainees.AsNoTracking().ToList();
        }

        public Trainee GetById(int id)
        {
            return dbContext.Trainees.FirstOrDefault(tra => tra.Id == id);
        }

        public void Insert(Trainee NewTrainee)
        {
            dbContext.Trainees.Add(NewTrainee);
            dbContext.SaveChanges();
        }
    }
}
