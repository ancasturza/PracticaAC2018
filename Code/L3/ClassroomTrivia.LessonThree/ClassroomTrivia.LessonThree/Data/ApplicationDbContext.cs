using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ClassroomTrivia.LessonThree.Models;
using ClassroomTrivia.LessonThree.Data.Entities;

namespace ClassroomTrivia.LessonThree.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<ClassroomTrivia.LessonThree.Data.Entities.Question> Question { get; set; }

        public DbSet<ClassroomTrivia.LessonThree.Data.Entities.Answer> Answer { get; set; }
    }
}
