using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ClassroomTrivia.LessonTwo.Data;
using ClassroomTrivia.LessonTwo.Models;
using ClassroomTrivia.LessonTwo.Services;

namespace ClassroomTrivia.LessonTwo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            // Use the service provider to get a instance of the database context object
            var context = service.GetService<ApplicationDbContext>();

            // Use the context instance to access the database and perform a migration
            context.Database.Migrate();

            // Call our CreateUserRoles method to make sure our roles exist.
            // The method asks for a IServiceProvider parameter and we will pass the one we created earlier.
            // Note that the method is asynchronous so we will have to wait for it.
            CreateUserRoles(service).Wait();
        }

        // A method we will use to make sure our user roles are created if they don't exist.
        private async Task CreateUserRoles(IServiceProvider service)
        {
            // Request a instance of the role manager.
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Create a variable to hold the result of the role manager when it creates a new role.
            IdentityResult identityResult;

            // Check if the administrator role exists.
            // Note that because the RoleExistsAsync method is asynchronous we need to wait for the result.
            var roleExists = await roleManager.RoleExistsAsync("Admin");
            if (!roleExists)
            {
                // If our role does not exist we need to create it.
                // First we need to create the administrator identity role.
                var adminRole = new IdentityRole("Admin");
                // Now we need to use the manager to create the role in the database.
                identityResult = await roleManager.CreateAsync(adminRole);
            }

            // Check if the professor role exists.
            roleExists = await roleManager.RoleExistsAsync("Professor");
            if (!roleExists)
            {
                // If our role does not exist we need to create it.
                // First we need to create the professor identity role.
                var professorRole = new IdentityRole("Professor");
                // Now we need to use the manager to create the role in the database.
                identityResult = await roleManager.CreateAsync(professorRole);
            }

            // Check if the student role exists.
            roleExists = await roleManager.RoleExistsAsync("Student");
            if (!roleExists)
            {
                // If our role does not exist we need to create it.
                // First we need to create the student identity role.
                var studentRole = new IdentityRole("Student");
                // Now we need to use the manager to create the role in the database.
                identityResult = await roleManager.CreateAsync(studentRole);
            }
        }
    }
}
