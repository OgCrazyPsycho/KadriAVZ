using Kadri_AVZ.Data;
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
using static Kadri_AVZ.PasswordHasher;

namespace Kadri_AVZ
{
    public partial class LogAndPass : Form
    {
        private readonly ApplicationDbContext _dbContext;

        public LogAndPass(ApplicationDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            
            var user = _dbContext.Administration.FirstOrDefault(u => u.Login == login);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            string hashedInput = ComputeSha256Hash(password);
            if (user.PasswordHash != hashedInput)
            {
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            
            MessageBox.Show($"Вход выполнен как {user.Role}", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Form formToOpen = user.Role switch
            {
                "Admin" => new WorkingKadri(user.Role, _dbContext),         // доступ ко всему
                "HR" => new WorkingKadri(user.Role, _dbContext),                  // только сотрудники
                "Accountant" => new AccountantForm(user.Role, _dbContext),       // только зарплаты
                _ => null
            };

            if (formToOpen != null)
            {
                formToOpen.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неизвестная роль пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
