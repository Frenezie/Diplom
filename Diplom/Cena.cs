using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Diplom
{
    public partial class Cena : Form
    {
        private readonly checkUser _user;
        DataBase DataBase = new DataBase();
        int SelectedRow;
        public Cena(checkUser user)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _user = user;
        }
        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id_Stoimost", "Id");
            dataGridView1.Columns.Add("VidOtdelMat", "Вид отделочного материала");
            dataGridView1.Columns.Add("Cvet", "Цвет");
            dataGridView1.Columns.Add("Stoimost", "Стоимость");
            dataGridView1.Columns.Add("Ostatok", "Остаток");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void clear_Fields()
        {
            cueTextBox1_Id.Text = "";
            cueTextBox2_VidOtdelMat.Text = "";
            cueTextBox3_Cvet.Text = "";
            cueTextBox1_Stoimost.Text = "";
            cueTextBox4_Ostatok.Text = "";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Stoimost";

            SqlCommand command = new SqlCommand(queryString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Cena_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }
        private void pictureBox1_Lastik_Click(object sender, EventArgs e)
        {
            clear_Fields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[SelectedRow];

                cueTextBox1_Id.Text = row.Cells[0].Value.ToString();
                cueTextBox2_VidOtdelMat.Text = row.Cells[1].Value.ToString();
                cueTextBox3_Cvet.Text = row.Cells[2].Value.ToString();
                cueTextBox1_Stoimost.Text = row.Cells[3].Value.ToString();
                cueTextBox4_Ostatok.Text = row.Cells[4].Value.ToString();
            }
        }

        private void pictureBox2_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void yt_Button1_New_Click(object sender, EventArgs e)
        {
            Add_Form2 add_Form = new Add_Form2();
            add_Form.Show();
        }
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Stoimost where concat (Id_Stoimost, VidOtdelMat, Cvet, Stoimost, Ostatok) like '%" + cueTextBox1_Poisk.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }

        private void cueTextBox1_Poisk_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;

                return;
            }
            dataGridView1.Rows[index].Cells[5].Value = RowState.Deleted;
        }

        private new void Update()
        {
            DataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)

                    continue;

                if (rowState == RowState.Deleted)
                {
                    var Id_Stoimost = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Stoimost where Id_Stoimost = {Id_Stoimost}";
                    var command = new SqlCommand(deleteQuery, DataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var Id_Stoimost = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var VidOtdelMat = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Cvet = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var Stoimost = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var Ostatok = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Stoimost set VidOtdelMat = '{VidOtdelMat}', Cvet = '{Cvet}', Stoimost = '{Stoimost}', Ostatok = '{Ostatok}' where Id_Stoimost = '{Id_Stoimost}'";

                    var command = new SqlCommand(changeQuery, DataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            DataBase.ClosedConnection();
        }

        private void yt_Button2_Delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            clear_Fields();
        }
        private void yt_Button4_Save_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Change()
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            var Id_Stoimost = cueTextBox1_Id.Text;
            var VidOtdelMat = cueTextBox2_VidOtdelMat.Text;
            var Cvet = cueTextBox3_Cvet.Text;
            int Stoimost;
            var Ostatok = cueTextBox4_Ostatok.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(cueTextBox1_Stoimost.Text, out Stoimost))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(Id_Stoimost, VidOtdelMat, Cvet, Stoimost, Ostatok);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Поле стоимость должено иметь числовой формат");
                }
            }
        }
        private void yt_Button3_Izmena_Click(object sender, EventArgs e)
        {
            Change();
            clear_Fields();
        }
        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            Form1.Show();
            this.Hide();
        }
        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Stoimost where concat (Id_Stoimost, VidOtdelMat, Cvet, Stoimost, Ostatok) like '%" + toolStripTextBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search2(dataGridView1);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
