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
        /// Первичная инициализация основного пользователя и ролей
        /// </summary>
        private void CreateMainRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            ApplicationUser resultUser = UserManager.FindByEmail("MainAdmin@apriorit.com");

            if (resultUser == null)
            {
                //Here we create a Admin user
                var user = new ApplicationUser();
                user.UserName = "MainAdmin@apriorit.com";
                user.Email = "MainAdmin@apriorit.com";
                
                string userPassword = "123Qwe!*)";

                var сreatingUserResult = UserManager.Create(user, userPassword);

                //Add default User to Role Admin   
                if (сreatingUserResult.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Admin");
                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            // creating Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }
    }
}
