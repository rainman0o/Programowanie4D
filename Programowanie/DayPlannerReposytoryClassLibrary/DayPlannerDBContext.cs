using DayPlannerReposytoryClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayPlannerReposytoryClassLibrary
{
    public partial class DayPlannerDBContext : DbContext
    {
        public DayPlannerDBContext()
        {
        }

        public DayPlannerDBContext(DbContextOptions<DayPlannerDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Plan> Plans { get; set; }

        public virtual DbSet<Plannerday> Plannerdays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseMySql("server=localhost;database=dayplanner4d;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    }
}
