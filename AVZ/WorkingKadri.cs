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
using Supabase;
using Kadri_AVZ.Models;
using System.Text.RegularExpressions;

namespace Kadri_AVZ
{
    public partial class WorkingKadri : Form
    {


        public WorkingKadri()
        {
            InitializeComponent();
            LoadEmployees();
            //LoadMaterials();
            //LoadEmployees();
            //LoadDetails();
            LoadLogs();
        }
        private void LoadEmployees()
        {
            using (var context = new ApplicationDbContext())
            {
                var requests = context.Users.ToList();
                if (dataGridViewR != null)
                    dataGridViewR.DataSource = requests;

                dataGridViewR.Columns["First_Name"].HeaderText = "Фамилия";
                dataGridViewR.Columns["Middle_Name"].HeaderText = "Имя";
                dataGridViewR.Columns["Last_Name"].HeaderText = "Отчество";
                dataGridViewR.Columns["Phone"].HeaderText = "Телефон";
                dataGridViewR.Columns["Email"].HeaderText = "Эл. почта";
                dataGridViewR.Columns["Address"].HeaderText = "Адрес";
                dataGridViewR.Columns["Job_Title"].HeaderText = "Должность";
                dataGridViewR.Columns["Department"].HeaderText = "Отдел";
                dataGridViewR.Columns["EmployeeCode"].HeaderText = "Код сотрудника";
                dataGridViewR.Columns["EmploymentStatus"].HeaderText = "Статус сотрудника";
            }
            using (var context = new ApplicationDbContext())
            {
                var requests = context.Users.ToList();
                if (dataGridViewE != null)
                    dataGridViewE.DataSource = requests;

                dataGridViewE.Columns["First_Name"].HeaderText = "Фамилия";
                dataGridViewE.Columns["Middle_Name"].HeaderText = "Имя";
                dataGridViewE.Columns["Last_Name"].HeaderText = "Отчество";
                dataGridViewE.Columns["Phone"].HeaderText = "Телефон";
                dataGridViewE.Columns["Email"].HeaderText = "Эл. почта";
                dataGridViewE.Columns["Address"].HeaderText = "Адрес";
                dataGridViewE.Columns["Job_Title"].HeaderText = "Должность";
                dataGridViewE.Columns["Department"].HeaderText = "Отдел";
                dataGridViewE.Columns["EmployeeCode"].HeaderText = "Код сотрудника";
                dataGridViewE.Columns["EmploymentStatus"].HeaderText = "Статус сотрудника";
            }
            foreach (DataGridViewColumn column in dataGridViewE.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
            foreach (DataGridViewColumn column in dataGridViewR.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void WatchRequest_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }


        private void AddEmployee_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(textBoxPhone.Text.Trim(), out long parsedPhone))
            {
                MessageBox.Show("Неверный формат номера телефона. Введите только цифры.");
                return;
            }
            string emailInput = textBoxEmail.Text.Trim();
            if (!IsValidEmail(emailInput))
            {
                MessageBox.Show("Неверный формат Email. Введите корректный адрес.");
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                var employee = new AVZ_User
                {
                    First_Name = textBoxSurname.Text.Trim(),
                    Middle_Name = textBoxName.Text.Trim(),
                    Last_Name = textBoxOtchestvo.Text.Trim(),
                    Phone = parsedPhone,
                    Email = textBoxEmail.Text.Trim(),
                    Address = textBoxAddress.Text.Trim(),
                    Job_Title = textBoxSpec.Text.Trim(),
                    Department = comboBox1.Text.Trim(),
                    EmployeeCode = GenerateEmployeeCode(textBoxSurname.Text.Trim(), textBoxName.Text.Trim()),
                    EmploymentStatus = "Активен" // Можно также дать возможность выбирать статус
                };
                context.Users.Add(employee);

                var logss = new AVZ_Log
                {
                    First_Name = textBoxSurname.Text.Trim(),
                    Middle_Name = textBoxName.Text.Trim(),
                    Last_Name = textBoxOtchestvo.Text.Trim(),
                    Job_Title = textBoxSpec.Text.Trim(),
                    Log_Date = DateTime.UtcNow,
                    Activity = "Добавлен новый сотрудник",

                };
                context.Logs.Add(logss);

                try
                {
                    context.SaveChanges();
                    MessageBox.Show("Сотрудник добавлен!");
                    LoadEmployees();
                    LoadLogs();
                    ClearAllFields(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении в базу данных:\n" + ex.Message + "\n" + ex.InnerException?.Message);
                }
            }
        }
        private void ClearAllFields(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                    textBox.Clear();
                else if (control is ComboBox comboBox)
                    comboBox.SelectedIndex = -1;
                else if (control is DateTimePicker datePicker)
                    datePicker.Value = DateTime.Now;
                else if (control.HasChildren)
                    ClearAllFields(control); // рекурсивно для вложенных панелей и групп
            }
        }
        private string GenerateEmployeeCode(string middleName, string firstName)
        {
            var initials = $"{middleName[0]}{firstName[0]}".ToUpper();
            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return $"{initials}-{timestamp}";
        }
        private void DltEmployee_Click(object sender, EventArgs e)
        {
            if (dataGridViewE.CurrentRow == null)
            {
                MessageBox.Show("Выберите сотрудника для удаления.");
                return;
            }
            
            var result = MessageBox.Show("Вы уверены, что хотите удалить выбранного сотрудника?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return; // Отмена действия
            }

            var id = Convert.ToInt64(dataGridViewE.CurrentRow.Cells["id_user"].Value);
            using (var context = new ApplicationDbContext())
            {
                var employee = context.Users.FirstOrDefault(e => e.id_user == id);
                if (employee != null)
                {

                    var logss = new AVZ_Log
                    {
                        First_Name = textBoxSurname.Text.Trim(),
                        Middle_Name = textBoxName.Text.Trim(),
                        Last_Name = textBoxOtchestvo.Text.Trim(),
                        Job_Title = textBoxSpec.Text.Trim(),
                        Log_Date = DateTime.UtcNow,
                        Activity = "Удалён сотрудник",

                    };
                    context.Logs.Add(logss);

                    // Удаление сотрудника
                    context.Users.Remove(employee);
                    context.SaveChanges();

                    MessageBox.Show("Сотрудник удален.");
                }

                LoadEmployees();
                LoadLogs();
            }
        }
        private void WatchEmployees_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void LoadLogs()
        {
            using (var context = new ApplicationDbContext())
            {
                var processes = context.Logs.ToList();
                if (dataGridViewP != null)
                    dataGridViewP.DataSource = processes;
                
                dataGridViewP.Columns["Log_Date"].HeaderText = "Время создания";
                dataGridViewP.Columns["First_Name"].HeaderText = "Фамилия";
                dataGridViewP.Columns["Middle_Name"].HeaderText = "Имя";
                dataGridViewP.Columns["Last_Name"].HeaderText = "Отчество";
                dataGridViewP.Columns["Job_Title"].HeaderText = "Должность";
                dataGridViewP.Columns["Activity"].HeaderText = "Действие";
                
                
            }
            foreach (DataGridViewColumn column in dataGridViewP.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void DeleteProcess_Click(object sender, EventArgs e)
        {
            if (dataGridViewP.CurrentRow == null)
            {
                MessageBox.Show("Выберите логи для удаления.");
                return;
            }
            var result = MessageBox.Show("Вы уверены, что хотите удалить данные логи?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
            {
                return; // Отмена действия
            }

            var id = Convert.ToInt64(dataGridViewP.CurrentRow.Cells["id_log"].Value);
            using (var context = new ApplicationDbContext())
            {
                var process = context.Logs.FirstOrDefault(p => p.id_log == id);
                if (process != null)
                {
                    context.Logs.Remove(process);
                    context.SaveChanges();
                    MessageBox.Show("Логи удалены.");
                    LoadLogs();
                }
            }
        }
        private void WatchProc_Click(object sender, EventArgs e)
        {
            LoadLogs();

        }

        private void textBoxDeviceName_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim().ToLower();

            using (var context = new ApplicationDbContext())
            {
                var filtered = context.Users
                    .Where(u =>
                        u.First_Name.ToLower().Contains(searchText) ||
                        u.Last_Name.ToLower().Contains(searchText) ||
                        u.Middle_Name.ToLower().Contains(searchText) ||
                        u.Phone.ToString().Contains(searchText) ||
                        u.Email.ToLower().Contains(searchText) ||
                        u.Address.ToLower().Contains(searchText) ||
                        u.Department.ToLower().Contains(searchText) ||
                        u.EmployeeCode.ToLower().Contains(searchText) ||
                        u.EmploymentStatus.ToLower().Contains(searchText) ||
                        u.Job_Title.ToLower().Contains(searchText)
                    )
                    .ToList();

                dataGridViewR.DataSource = filtered;
            }
        }

        private void textBoxSearchLog_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearchLog.Text.Trim().ToLower();

            using (var context = new ApplicationDbContext())
            {
                var logs = context.Logs.ToList(); // Загружаем все логи в память

                var filteredLogs = logs.Where(log =>
                    (log.Activity ?? "").ToLower().Contains(searchText) ||
                    (log.First_Name ?? "").ToLower().Contains(searchText) ||
                    (log.Middle_Name ?? "").ToLower().Contains(searchText) ||
                    (log.Last_Name ?? "").ToLower().Contains(searchText) ||
                    (log.Job_Title ?? "").ToLower().Contains(searchText) ||
                    log.Log_Date.ToString("dd.MM.yyyy HH:mm").ToLower().Contains(searchText)
                ).ToList();

                dataGridViewP.DataSource = filteredLogs;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private string _userRole;
        private readonly ApplicationDbContext _dbContext;

        public WorkingKadri(string userRole, ApplicationDbContext dbContext)
        {
            InitializeComponent();
            _userRole = userRole;
            _dbContext = dbContext;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void WorkingKadri_Load(object sender, EventArgs e)
        {
            if (_userRole == "HR")
            {
                DeleteProcess.Enabled = false;        
                toolStrip1.Visible = false;
            }
            else if (_userRole == "Admin")
            {
                // Ничего не скрываем
            }
            LoadEmployees();
            LoadLogs();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var AccountantForm = new AccountantForm(_userRole, _dbContext);
            AccountantForm.Show();
            this.Hide();
        }
    }
}
