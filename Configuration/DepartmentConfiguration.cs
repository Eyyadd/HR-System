using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_2ITI.Models;

namespace Task_2ITI.Configuration
{
    public class DepartmentConfiguration:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Relation between Department and Instructor
            builder
                 .HasMany(dep => dep.Instructors)
                 .WithOne(ins => ins.Department)
                 .HasForeignKey(fk => fk.DepID)
                 .HasPrincipalKey(pk => pk.Id)
                 .OnDelete(DeleteBehavior.NoAction);

            //Relation between Department and Trainee
            builder
                .HasMany(dep => dep.Trainees)
                .WithOne(tra => tra.Department)
                .HasForeignKey(fk => fk.DepID)
                .HasPrincipalKey(pk => pk.Id);

            //Relation between Department and Course
            builder
                .HasMany(dep => dep.Courses)
                .WithOne(crs => crs.Department)
                .HasForeignKey(fk => fk.DepId)
                .HasPrincipalKey(pk => pk.Id);



        }

    }
}
