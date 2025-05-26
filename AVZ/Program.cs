using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Kadri_AVZ.Data;
using Kadri_AVZ;

namespace Kadri_AVZ
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Настройка строки подключения
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("Host=aws-0-eu-west-2.pooler.supabase.com;Port=5432;Database=postgres;Username=postgres.nnskmgwkfpzfwsgifwot;Password=qwe12345;");

            // Создание контекста вручную
            using var dbContext = new ApplicationDbContext(optionsBuilder.Options);

            // Передача контекста в форму (если форма принимает его в конструктор)
            var loginForm = new LogAndPass(dbContext);
            Application.Run(loginForm);

            
        }
    }
}
