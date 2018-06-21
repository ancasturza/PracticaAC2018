using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClassroomTrivia.LessonOne.Models;

namespace ClassroomTrivia.LessonOne.Data
{
    public class ClassroomTriviaContext : DbContext
    {
        public ClassroomTriviaContext(DbContextOptions<ClassroomTriviaContext> options)
            : base(options)
        {
        }

        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
    }
}
