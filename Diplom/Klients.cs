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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Diplom
{
    public partial class Klients : Form
    {
        private readonly checkUser _user;
        DataBase DataBase = new DataBase();
        int SelectedRow;
        public Klients(checkUser user)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _user = user;
        }

            private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id_Klient", "Id");
            dataGridView1.Columns.Add("FIO", "ФИО");
            dataGridView1.Columns.Add("Adress", "Адрес");
            dataGridView1.Columns.Add("VidOtdelMat", "Вид материала");
            dataGridView1.Columns.Add("Cvet", "Цвет");
            dataGridView1.Columns.Add("Phone", "Номер");
            dataGridView1.Columns.Add("FIO_Sotrudnik", "ФИО Продавца");
            dataGridView1.Columns.Add("Stoimost", "Стоимость");
            dataGridView1.Columns.Add("Kolichestvo", "Количество");
            dataGridView1.Columns.Add("Itogo", "Итого");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void clear_Fields()
        {
            cueTextBox1_Id.Text = "";
            cueTextBox2_FIO.Text = "";
            cueTextBox3_Adress.Text = "";
            cueTextBox4_VidOtdelMat.Text = "";
            cueTextBox5_Cvet.Text = "";
            cueTextBox6_Phone.Text = "";
            cueTextBox1.Text = "";
            cueTextBox7_Stoimost.Text = "";
            cueTextBox8_Kolichestvo.Text = "";
            cueTextBox9_Itogo.Text = "";
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetInt32(7), record.GetInt32(8), record.GetInt32(9), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Klient";

            SqlCommand command = new SqlCommand(queryString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Klients_Load(object sender, EventArgs e)
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
                cueTextBox2_FIO.Text = row.Cells[1].Value.ToString();
                cueTextBox3_Adress.Text = row.Cells[2].Value.ToString();
                cueTextBox4_VidOtdelMat.Text = row.Cells[3].Value.ToString();
                cueTextBox5_Cvet.Text = row.Cells[4].Value.ToString();
                cueTextBox6_Phone.Text = row.Cells[5].Value.ToString();
                cueTextBox1.Text = row.Cells[6].Value.ToString();
                cueTextBox7_Stoimost.Text = row.Cells[7].Value.ToString();
                cueTextBox8_Kolichestvo.Text = row.Cells[8].Value.ToString();
                cueTextBox9_Itogo.Text = row.Cells[9].Value.ToString();
            }
        }

        private void pictureBox2_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void yt_Button1_New_Click(object sender, EventArgs e)
        {
            Add_Form4 add_Form = new Add_Form4();
            add_Form.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Klient where concat (Id_Klient,FIO,Adress,VidOtdelMat,Cvet,Phone,FIO_Sotrudnik,Stoimost,Kolichestvo,Itogo) like '%" + cueTextBox1_Poisk.Text + "%'";

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
                dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;

                return;
            }
            dataGridView1.Rows[index].Cells[10].Value = RowState.Deleted;
        }

        private new void Update()
        {
            DataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[10].Value;

                if (rowState == RowState.Existed)

                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Klient where Id_Klient = {id}";
                    var command = new SqlCommand(deleteQuery, DataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var Id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var FIO = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Adress = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var VidOtdelMat = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var Cvet = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var Phone = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var FP = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var Stoimost = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var Kolichestvo = dataGridView1.Rows[index].Cells[8].Value.ToString();
                    var Itogo = dataGridView1.Rows[index].Cells[9].Value.ToString();

                    var changeQuery = $"update Klient set FIO = '{FIO}', Adress = '{Adress}',VidOtdelMat = '{VidOtdelMat}',Cvet = '{Cvet}',Phone = '{Phone}',FIO_Sotrudnik = '{FP}', Stoimost = '{Stoimost}',Kolichestvo = '{Kolichestvo}',Itogo= '{Itogo}' where Id_Klient = '{Id}'";

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

            var Id = cueTextBox1_Id.Text;
            var FIO = cueTextBox2_FIO.Text;
            var Adress = cueTextBox3_Adress.Text;
            var VidOtdelMat = cueTextBox4_VidOtdelMat.Text;
            var Cvet= cueTextBox5_Cvet.Text;
            var Phone = cueTextBox6_Phone.Text;
            var FP = cueTextBox1.Text;
            int Stoimost;
            var Kolichestvo = cueTextBox8_Kolichestvo.Text;
            var Itogo = cueTextBox9_Itogo.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(cueTextBox7_Stoimost.Text, out Stoimost))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(Id, FIO, Adress, VidOtdelMat, Cvet, Phone, FP, Stoimost, Kolichestvo, Itogo);
                    dataGridView1.Rows[selectedRowIndex].Cells[10].Value = RowState.Modified;
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void запрос1СуммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zaprosString = "UPDATE Klient\r\nSET Itogo = Stoimost * Kolichestvo ";
            SqlCommand command = new SqlCommand(zaprosString, DataBase.getConnection());
            DataBase.openConnection();
            command.ExecuteNonQuery();
            DataBase.ClosedConnection();
        }
        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Klient where concat (Id_Klient,FIO,Adress,VidOtdelMat,Cvet,Phone,FIO_Sotrudnik,Stoimost,Kolichestvo,Itogo) like '%" + toolStripTextBox1.Text + "%'";

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
    }
}