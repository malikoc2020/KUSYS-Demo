using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Context.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Cources","dbo");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.CourseCode).IsUnique();
            builder.HasData(new Course() { Id=1, CourseCode = "CSI101", Name= "Introduction to Computer Science", DateCreated=DateTime.Now, IsActive=true, CreatedUserId = ContextSeed.TanimsizUserId },
                new Course() { Id = 2, CourseCode = "CSI102", Name = "Algorithms", DateCreated = DateTime.Now, IsActive = true, CreatedUserId = ContextSeed.TanimsizUserId },
                new Course() { Id = 3, CourseCode = "MAT101", Name = "Calculus", DateCreated = DateTime.Now, IsActive = true, CreatedUserId = ContextSeed.TanimsizUserId },
                new Course() { Id = 4, CourseCode = "PHY101", Name = "Physics", DateCreated = DateTime.Now, IsActive = true, CreatedUserId = ContextSeed.TanimsizUserId });   
        }
    }
}
