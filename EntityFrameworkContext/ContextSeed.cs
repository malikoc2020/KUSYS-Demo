﻿using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace EFCore.Context
{
    public class ContextSeed
    {
        public static async Task SeedRoleAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new Role(Roles.User.ToString()));
        }
        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            List<User> users = new List<User>();

            User tanimsiz = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Tanımsız",
                LastName = "Tanimsiz",
                UserName = "Tanimsiz",
                Email = "Tanimsiz@Tanimsiz.com",
                PhoneNumber = "Tanimsiz",
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TC = "",
                PictureUrl = "",
                DefaultRole =""

                //Password = "hKaoJdFbclk=",/*123456*/
            };
            users.Add(tanimsiz);


            User Admin = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin",
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
                    {

                        //throw e;
                    }
                   /* var result = await userManager.CreateAsync(usr, "Sifre%5");
                    if (result.Succeeded && !String.IsNullOrEmpty(usr.DefaultRole))
                    {
                        await userManager.AddToRoleAsync(usr, usr.DefaultRole);
                    }
                   */
                }
            }



        }
    }
}
