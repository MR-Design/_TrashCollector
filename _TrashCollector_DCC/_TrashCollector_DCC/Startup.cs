﻿using _TrashCollector_DCC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
[assembly: OwinStartupAttribute(typeof(_TrashCollector_DCC.Startup))]
namespace _TrashCollector_DCC
{
    //public partial class Startup
    //{
        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);

        //}




        // MDN   Way

        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                ConfigureAuth(app);
                createRolesandUsers();
            }


            // In this method we will create default User roles and Admin user for login 
            private void createRolesandUsers()
            {
                ApplicationDbContext context = new ApplicationDbContext();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


                // In Startup iam creating first Admin Role and creating a default Admin User  
                if (!roleManager.RoleExists("Admin"))
                {

                    // first we create Admin rool 
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                 

                    var user = new ApplicationUser();
                    user.UserName = "MohammedRD";
                    user.Email = "mooohammedrd@gmail.com";

                    string userPWD = "@Abcd1234";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin 
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");

                    }
                }

                // creating Creating Manager role  
                if (!roleManager.RoleExists("Employee"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Employee";
                    roleManager.Create(role);

                }

                // creating Creating Employee role  
                if (!roleManager.RoleExists("Customer"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Customer";
                    roleManager.Create(role);

                }
            }
        }






    ////////////////
    //public void Configuration(IAppBuilder app)
    //{
    //    ConfigureAuth(app);
    //    createRolesandUsers();
    //}


    //// In this method we will create default User Employee and  user Cusomer for login   
    //private void createRolesandUsers()
    //{
    //    ApplicationDbContext context = new ApplicationDbContext();

    //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
    //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


    //    // In Startup iam creating first Admin Role and creating a default Admin User    
    //    if (!roleManager.RoleExists("Customer"))
    //    {

    //        // first we create Admin rool   
    //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
    //        role.Name = "Customer";
    //        roleManager.Create(role);

    //        //Here we create a Admin super user who will maintain the website                  

    //        //var user = new ApplicationUser();
    //        ////user.UserName = "shanu";
    //        ////user.Email = "syedshanumcain@gmail.com";

    //        //string userPWD = "A@Z200711";

    //        //var chkUser = UserManager.Create(user, userPWD);

    //        ////Add default User to Role Admin   
    //        //if (chkUser.Succeeded)
    //        //{
    //        //    var result1 = UserManager.AddToRole(user.Id, "Customer");

    //        //}
    //    }

    //    // creating Creating Manager role    
    //    //if (!roleManager.RoleExists("Customer"))
    //    //{
    //    //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
    //    //    role.Name = "Customer";
    //    //    roleManager.Create(role);

    //    //}

    //    // creating Creating Employee role    
    //    if (!roleManager.RoleExists("Employee"))
    //    {
    //        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
    //        role.Name = "Employee";
    //        roleManager.Create(role);

    //    }
    //}


}
