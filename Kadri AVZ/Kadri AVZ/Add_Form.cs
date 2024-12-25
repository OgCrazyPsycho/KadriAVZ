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
    public partial class Add_Form : Form
    {
        DataBase database = new DataBase();
        public Add_Form()
        {
            InitializeComponent();
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnect();

            var name = NametextBox2.Text;
            var Familia = FamtextBox3.Text;
            var Otchestvo = OtchtextBox4.Text;
            long phone;
            var Job = JobtextBox6.Text;
            

            if (long.TryParse(PhotextBox5.Text, out phone))
            {
                var addQuery = $"insert into Users (name_user, Familia_user, Otchestvo_user, phone, Job) values ('{name}', '{Familia}', '{Otchestvo}','{phone}','{Job}')";

                var command = new SqlCommand(addQuery, database.getConnect());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Номер телефона должен иметь числовой формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            database.closeConnect();
        }
    }
}
