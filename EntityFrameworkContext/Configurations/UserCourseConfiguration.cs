using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Context.Configurations
{
     public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> userCourse)
        {
            userCourse.ToTable("UserCources", "dbo");
            userCourse.HasKey(ur => ur.Id);
            userCourse.HasIndex(e => new { e.UserId, e.CourseId }).IsUnique();


            userCourse.HasOne(ur => ur.User)
                     .WithMany(r => r.UserCourses)
                     .HasForeignKey(ur => ur.UserId);

            userCourse.HasOne(ur => ur.Course)
                .WithMany(r => r.CourseUsers)
                .HasForeignKey(ur => ur.CourseId);
        }
    }
}
