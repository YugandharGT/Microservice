﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderMyFood.TokenApi.Models;

namespace OrderMyFood.TokenApi.Data
{
    public class IdentityDbInit
    {
        //This example just creates an Administrator role and one Admin users
        public static async void Initialize(
            IdentityAppContext context,
            UserManager<ApplicationUser> userManager)
        {
            //create database schema if none exists
            //context.Database.EnsureCreated();
           //context.Database.Migrate();
            //If there is already an Administrator role, abort
            //if (context.Roles.Any(r => r.Name == "Administrator")) return;

            //Create the Administartor Role
            //await roleManager.CreateAsync(new IdentityRole("Administrator"));
            if (context.Users.Any(r => r.UserName == "me@myemail.com")) return;
            //Create the default Admin account and apply the Administrator role
            string user = "me@myemail.com";
            string password = "P@ssword1";
            await userManager.CreateAsync(new ApplicationUser { UserName = user, Email = user, EmailConfirmed = true }, password);
            //   await userManager.AddToRoleAsync(await userManager.FindByNameAsync(user), "Administrator");
        }

    }
}
