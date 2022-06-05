using Domain.Entities;
using EFCore.Context.Configurations;
//using EntityFramework.Context.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //Şema belirlenmez ise tablo dbo şemasında oluşsun.
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new UserCourseConfiguration());
           

            builder.Entity<User>(entity =>
            {
                entity.ToTable("User", "Identity");
            });
            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "Identity");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims", "Identity");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });
            builder.Entity<UserRole>(userRole =>
            {
                userRole.ToTable("UserRoles", "Identity");

                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId);

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId);
            });
        }

     
    }
}
