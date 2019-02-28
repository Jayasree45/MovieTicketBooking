using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MovieTicketBooking.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieTicketBooking.Startup))]
namespace MovieTicketBooking
{
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

                // first we create Admin role    
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                //Here we create a Admin super user who will maintain the website                   
                var user = new ApplicationUser();
                //user.UserName = "Admin";
                user.Email = "alim@gmail.com";
                string pwd = "Pass@123";

                var chkUser = UserManager.Create(user, pwd);

                //Add default User to Role Admin    
                if (chkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");

                }
            }
            //creating Creating Employee role
           

            ////creating Creating Employee role
            //if (!roleManager.RoleExists("Customer"))
            //{
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Customer";
            //    roleManager.Create(role);

            //}
        }
    }

}

