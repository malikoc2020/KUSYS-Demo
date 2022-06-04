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
        //public DbSet<Block> Blocks { get; set; }
        //public DbSet<Flat> Flats { get; set; }
        //public DbSet<FlatType> FlatTypes { get; set; }
        //public DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfiguration(new CourseConfiguration());
            //builder.ApplyConfiguration(new BlockConfiguration());
            //builder.ApplyConfiguration(new FlatConfiguration());
            //builder.ApplyConfiguration(new UserTypeConfiguration());
            //builder.ApplyConfiguration(new FlatTypeConfiguration());
            //builder.ApplyConfiguration(new BillConfiguration());
            //builder.ApplyConfiguration(new BillFlatConfiguration());
            //builder.ApplyConfiguration(new BillTypeConfiguration());
            //builder.ApplyConfiguration(new MessageConfiguration());

            builder.HasDefaultSchema("Identity");
            builder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });
            builder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            builder.Entity<UserRole>(userRole =>
            {
                userRole.ToTable("UserRoles");

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
