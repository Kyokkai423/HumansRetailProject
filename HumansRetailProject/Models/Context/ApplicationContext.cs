using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HumansRetailProject.Models.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        { }
        public DbSet<Points> Points { get; set; }
        public DbSet<PointCheckList> CheckLists { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<CheckLog> CheckLogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Points>().ToTable("Points"); // Название таблицы
            modelBuilder.Entity<Users>().ToTable("Users"); // Название таблицы
            modelBuilder.Entity<PointCheckList>().ToTable("PointCheckList"); // Название таблицы
            modelBuilder.Entity<CheckLog>().ToTable("CheckLog"); // Название таблицы
        }
    }
}