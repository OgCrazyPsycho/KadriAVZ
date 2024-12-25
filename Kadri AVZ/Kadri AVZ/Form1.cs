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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kadri_AVZ
{

    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Delited
    }
    public partial class Form1 : Form
    {
        DataBase database = new DataBase();
        int selectedRow;
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_User", "id сотрудника");
            dataGridView1.Columns.Add("name_user", "Имя");
            dataGridView1.Columns.Add("Familia_user", "Фамилия");
            dataGridView1.Columns.Add("Otchestvo_user", "Отчество");
            dataGridView1.Columns.Add("phone", "Телефон");
            dataGridView1.Columns.Add("Job", "Должность");
            
            dataGridView1.Columns.Add("Isnew", String.Empty);
        }

        private void ReadSingleRow1(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetInt64(4), record.GetString(5), RowState.ModifiedNew);  

        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string qS = $"select * from Users";

            SqlCommand command = new SqlCommand(qS, database.getConnect());

            database.openConnect();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow1(dgw, reader);
            }
            reader.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                IDtextBox1.Text = row.Cells[0].Value.ToString();
                NametextBox2.Text = row.Cells[1].Value.ToString();
                FamtextBox3.Text = row.Cells[2].Value.ToString();
                OtchtextBox4.Text = row.Cells[3].Value.ToString();
                PhotextBox5.Text = row.Cells[4].Value.ToString();
                JobtextBox6.Text = row.Cells[5].Value.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_record_Click(object sender, EventArgs e)
        {
            Add_Form addfrm = new Add_Form();
            addfrm.Show();
        }

        private void pictureBox_Arrow_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }
        private void ClearFields()
        {
            IDtextBox1.Text = "";
            NametextBox2.Text = "";
            FamtextBox3.Text = "";
            OtchtextBox4.Text = "";
            PhotextBox5.Text = "";
            JobtextBox6.Text = "";
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void Search(DataGridView dgw) //Users where (id_User, name_user, Familia_user, Otchestvo_user, phone, Job)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Users where concat (id_User, name_user, Familia_user, Otchestvo_user, phone, Job) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnect());

            database.openConnect();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow1(dgw, read);
            }
            read.Close();
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RowState.Delited;
                return;
            }
            dataGridView1.Rows[index].Cells[6].Value = RowState.Delited;

        }

        private void Update()
        {
            database.openConnect();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Delited)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Users where id_User = {id} ";

                    var command = new SqlCommand(deleteQuery, database.getConnect());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Familia = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var Otchestvo = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var Phone = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var Job = dataGridView1.Rows[index].Cells[5].Value.ToString();

                    var changeQuery = $"update Users set name_user = '{name}', Familia_user = '{Familia}', Otchestvo_user ='{Otchestvo}', phone ='{Phone}', Job ='{Job}' where id_User = '{id}'";

                    var command = new SqlCommand(changeQuery, database.getConnect());
                    command.ExecuteNonQuery();
                }
            }
            database.closeConnect();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
            Update();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var id_User = IDtextBox1.Text;
            var name = NametextBox2.Text;
            var Familia = FamtextBox3.Text;
            var Otchestvo = OtchtextBox4.Text;
            long Phone;
            var Job = JobtextBox6.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (long.TryParse(PhotextBox5.Text, out Phone))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(id_User, name, Familia, Otchestvo, Phone, Job);
                    dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Номер телефона должен иметь числовой формат!");
                }
            }
        }

        private void pictureBox_eraser_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
