using Kadri_AVZ.Data;
using Kadri_AVZ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadri_AVZ
{
    public partial class AccountantForm : Form
    {


        private readonly ApplicationDbContext _db;
        private string _userRole;

        public AccountantForm(string userRole, ApplicationDbContext dbContext)
        {
            InitializeComponent();
            _db = dbContext;        
            _userRole = userRole;
            LoadEmployeesWithSalaries();
        }

        private void LoadEmployeesWithSalaries()
        {
            using (var context = new ApplicationDbContext())
            {
                var employeesWithSalaries = from user in context.Users
                join salary in context.Salaries
                 on user.id_user equals salary.EmployeeId into salaryGroup
                 from s in salaryGroup.OrderByDescending(x => x.Date).Take(1).DefaultIfEmpty()
                   select new
                   {
                     ID = user.id_user,
                     Фамилия = user.First_Name,
                     Имя = user.Middle_Name,
                     Код = user.EmployeeCode,
                     Должность = user.Job_Title,
                     Отдел = user.Department,
                     Зарплата = s != null ? s.Amount : (decimal?)null
                   };

                salaryGridView.DataSource = employeesWithSalaries.ToList();
            }
        }
        private void salaryGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (salaryGridView.CurrentRow != null)
            {
                var salaryCell = salaryGridView.CurrentRow.Cells["Зарплата"].Value;
                textBoxSalary.Text = salaryCell?.ToString() ?? "";
            }
        }


        private void AddSalary_Click_1(object sender, EventArgs e)
        {
            if (salaryGridView.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника.");
                return;
            }

            if (!decimal.TryParse(textBoxSalary.Text.Trim(), out decimal newSalary))
            {
                MessageBox.Show("Введите корректную сумму.");
                return;
            }

            long employeeId = Convert.ToInt64(salaryGridView.CurrentRow.Cells["id"].Value);

            using (var context = new ApplicationDbContext())
            {
                var latestSalary = context.Salaries
                    .Where(s => s.EmployeeId == employeeId)
                    .OrderByDescending(s => s.Date)
                    .FirstOrDefault();

                if (latestSalary != null)
                {
                    latestSalary.Amount = newSalary;
                    latestSalary.Date = DateTime.UtcNow;
                }
                else
                {
                    context.Salaries.Add(new AVZ_Salary
                    {
                        EmployeeId = employeeId,
                        Amount = newSalary,
                        Date = DateTime.UtcNow
                    });
                }

                context.SaveChanges();
                MessageBox.Show("Зарплата обновлена.");
                LoadEmployeesWithSalaries();
            }
        }

        private void DeleteSalary_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadEmployeesWithSalaries();
        }

        private void AccountantForm_Load(object sender, EventArgs e)
        {
            if (_userRole == "Accountant")
            {
                menuStrip1.Visible = false;        // Пример: скрытие кнопки
            }
            else if (_userRole == "Admin")
            {
                // Ничего не скрываем
            }
        }
        

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var kadriForm = new WorkingKadri(_userRole, _db);
            kadriForm.Show();
            this.Hide();
        }
    }
}

