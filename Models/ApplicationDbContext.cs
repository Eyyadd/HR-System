using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task_2ITI.Application;
using Task_2ITI.Configuration;

namespace Task_2ITI.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptionsBuilder options){ }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=DESKTOP-A7K294K\\SQLEXPRESS;Initial Catalog=ITICourseDatabase;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            base.OnModelCreating(modelBuilder);

            //modelBuilder
            //    .Entity<Trainee>()
            //    .HasMany(tra => tra.Courses)
            //    .WithMany(crs => crs.Trainees)
            //    .UsingEntity<CoursesResult>
            //    (
            //        tra => tra.HasOne(tra => tra.Course).WithMany(crs => crs.CoursesResults).HasForeignKey(fk => fk.CourseId).OnDelete(DeleteBehavior.NoAction),
            //        crs => crs.HasOne(crs => crs.Trainee).WithMany(tra => tra.CourseResults).HasForeignKey(fk => fk.TraineeId).OnDelete(DeleteBehavior.NoAction),
            //        pk => pk.HasKey(pk => new { pk.CourseId, pk.TraineeId })
            //    );



        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Course> Courses { get; set; }
     //   public DbSet<CoursesResult> CoursesResult { get; set; }
    }
}
