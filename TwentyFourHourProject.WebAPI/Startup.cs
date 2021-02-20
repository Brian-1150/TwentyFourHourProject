using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TwentyFourHourProject.WebAPI.Startup))]

namespace TwentyFourHourProject.WebAPI
{
    public partial class Startup
    {

        //method goes here
        //method to create users and user roles
        //role manager
        //user manager
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //call method from here
        }
    }
}

//private void createRolesAndUsers()
//{
//    ApplicationDbContext context = new ApplicationDbContext();

//    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
//    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

//    if (!roleManager.RoleExists("Admin"))
//    {

//        first we create Admin role
//       var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
//        role.Name = "Admin";
//        roleManager.Create(role);

//        Here we create a Admin super user who will maintain the website
//        var user = new ApplicationUser();
//        user.UserName = "bpcampassi";
//        user.Email = "bpcampassi@gmail.com";
//        user.DisplayName = "Brian";

//        string userPWD = "Password123!";

//        var chkUser = userManager.Create(user, userPWD);
