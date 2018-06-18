using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleMVC.Models;

namespace SimpleMVC.Data
{
    public class QuestionsContext : DbContext
    {
        public QuestionsContext (DbContextOptions<QuestionsContext> options)
            : base(options)
        {
        }

        public DbSet<SimpleMVC.Models.Question> Question { get; set; }
    }
}
