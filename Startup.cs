using HomeLibrary.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeLibrary.Startup))]
namespace HomeLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup creating first Admin Role and creating a default users
            if (!roleManager.RoleExists("Admin"))
            {

                // Creating Admin role
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                // Creating Admin super user who will maintain the website                        
                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com";
                user.Email = "admin@gmail.com";

                string userPWD = "123456";
                var chkUser = UserManager.Create(user, userPWD);

                // Creating user wihtout any role                        
                var user2 = new ApplicationUser();
                user2.UserName = "user@gmail.com";
                user2.Email = "user@gmail.com";

                string userPWD2 = "123456";
                var chkUser2 = UserManager.Create(user2, userPWD2);

                // Adding Admin User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
