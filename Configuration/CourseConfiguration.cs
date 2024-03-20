using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task_2ITI.Models;

namespace Task_2ITI.Configuration
{
    public class CourseConfiguration:IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasMany(crs => crs.Instructors)
                .WithOne(ins => ins.Course)
                .HasForeignKey(fk => fk.CourseId)
                .HasPrincipalKey(pk => pk.Id);
        }
    }
}
