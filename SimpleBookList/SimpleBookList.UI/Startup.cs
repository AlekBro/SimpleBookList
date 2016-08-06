// -----------------------------------------------------------------------
// <copyright file="Startup.cs" company="AlekBro">
//     AlekBro. All rights reserved.
// </copyright>
// <author>AlekBro</author>
// -----------------------------------------------------------------------
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

using SimpleBookList.UI.IdentityModels;

[assembly: OwinStartupAttribute(typeof(SimpleBookList.UI.Startup))]
namespace SimpleBookList.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            CreateMainRolesAndUsers();
        }

        /// <summary>
        /// Primary initialization for test Admin and test User users
        /// </summary>
        private void CreateMainRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Creating Admin Role
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            // Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }

            ApplicationUser resultAdmin = UserManager.FindByEmail("TestAdmin@test.com");
            if (resultAdmin == null)
            {
                //Here we create a Admin user
                var user = new ApplicationUser();
                user.UserName = "TestAdmin@test.com";
                user.Email = "TestAdmin@test.com";
                
                string userPassword = "123Qwe!*)";

                var сreatingUserResult = UserManager.Create(user, userPassword);

                //Add default User to Role Admin and User  
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                    UserManager.AddToRole(user.Id, "User");
                }
            }

            ApplicationUser resultUser = UserManager.FindByEmail("TestUser@test.com");
            if (resultUser == null)
            {
                var user = new ApplicationUser();
                user.UserName = "TestUser@test.com";
                user.Email = "TestUser@test.com";

                string userPassword = "123Qwe!*)";

                var сreatingUserResult = UserManager.Create(user, userPassword);
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "User");
                }
            }
        }
    }
}
