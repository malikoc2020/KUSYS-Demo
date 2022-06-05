using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EFCore.Context
{
    public class UserRoleSeed
    {
        //Uygulama ilk ayağa kalktığında Kullanıcılar ve roller burada veritabanına yazılıyor. 



        //system isimli kullanıcı için tanımlanmış sabit user id. kullanıcısı belli olmayan yada seed olarak oluşturalan satırların inserteduserid olarak bu id kullanılacak.
        public static Guid TanimsizUserId = Guid.Parse("f7882daa-fe0c-4fd1-9656-c2e9426c5fda");
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new Role(Roles.User.ToString()));
        }
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            List<User> users = new List<User>();

            User SystemUser = new User()
            {
                Id = TanimsizUserId.ToString(),
                FirstName = "System",
                LastName = "System",
                UserName = "System",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "System@System.com",
                PhoneNumber = "System",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TC = "",
                PictureUrl = "",
                DefaultRole =""
            };
            users.Add(SystemUser);


            User Admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "Admin@Admin.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TC = "-1",
                PictureUrl = "",
                DefaultRole = "Admin"
            };
            users.Add(Admin);

            User student = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "student",
                LastName = "student",
                UserName = "student",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "student@student.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TC = "12345678910",
                PictureUrl = "",
                DefaultRole = "User"
            };
            users.Add(student);


            User student2 = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "student2",
                LastName = "student2",
                UserName = "student2",
                BirthDate = new DateTime(2000, 1, 1),
                Email = "student2@student.com",
                PhoneNumber = "",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TC = "12345678911",
                PictureUrl = "",
                DefaultRole = "User"
            };
            users.Add(student2);

            foreach (var usr in users)
            {
                var userEntity = await userManager.FindByEmailAsync(usr.Email);
                if (userEntity == null)
                {
                    try
                    {
                        var result = await userManager.CreateAsync(usr, "Sifre%5");
                        if (result.Succeeded && !String.IsNullOrEmpty(usr.DefaultRole))
                        {
                            await userManager.AddToRoleAsync(usr, usr.DefaultRole);
                        }
                    }
                    catch (Exception e)
                    {//Seed işleminde hata alırsa exception fırlatma. 
                        //throw e;
                    }
                }
            }



        }
    }
}
