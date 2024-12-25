using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kadri_AVZ
{
    public partial class Autorization : Form
    {
        DataBase dataBase = new DataBase();
        public Autorization()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LogintextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogINbutton_Click(object sender, EventArgs e)
        {
            var login = LogintextBox.Text;
            var password = PasswordtextBox.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_User, login_User, Password_user from Administration where login_User = '{login}' and password_user = '{password}' ";

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnect());

            adapter.SelectCommand = command;
            adapter.Fill(table);



            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm1 = new Form1();
                this.Hide();
                
                //frm1.ShowDialog();
                frm1.Show();

            }
            else
            {
                MessageBox.Show("Такой аккаунт отсутствует", "аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
