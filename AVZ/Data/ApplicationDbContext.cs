using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Extensions.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;
using Kadri_AVZ.Models;

namespace Kadri_AVZ.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AVZ_Administration> Administration { get; set; }
        public DbSet<AVZ_Log> Logs { get; set; }
        
        public DbSet<AVZ_User> Users { get; set; }

        public DbSet<AVZ_Salary> Salaries { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ЗАМЕНИ на свою строку подключения
            optionsBuilder.UseNpgsql("Host=aws-0-eu-west-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.nnskmgwkfpzfwsgifwot;Password=qwe12345;");
        } 

        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AVZ_User>()
        .HasKey(a => a.id_user);

            modelBuilder.Entity<AVZ_Log>()
        .HasKey(a => a.id_log);

            modelBuilder.Entity<AVZ_Administration>()
        .HasKey(a => a.idAdm);
           
            modelBuilder.Entity<AVZ_Salary>()
        .HasKey(a => a.id);
        }

    }
}
