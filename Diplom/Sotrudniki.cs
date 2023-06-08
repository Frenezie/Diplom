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
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Sotrudniki : Form
    {
        private readonly checkUser _user;
        DataBase DataBase = new DataBase();
        int SelectedRow;

        public Sotrudniki(checkUser user)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _user = user;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("Id_Sotrudniki", "Id");
            dataGridView1.Columns.Add("FIO_Sotrudnik", "ФИО");
            dataGridView1.Columns.Add("Gender", "Пол");
            dataGridView1.Columns.Add("Vozrast", "Возраст");
            dataGridView1.Columns.Add("doljnost", "Должность");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        }

        private void clear_Fields()
        {
            cueTextBox1_Id.Text = "";
            cueTextBox2_FIO.Text = "";
            cueTextBox3_Gender.Text = "";
            cueTextBox1_Vozrast.Text = "";
            cueTextBox4_Doljnost.Text = "";
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetInt32(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Sotrudniki";

            SqlCommand command = new SqlCommand(queryString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();
        }

        private void Sotrudniki_Load(object sender, EventArgs e)
        {
            Is_Admin();
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
                cueTextBox3_Gender.Text = row.Cells[2].Value.ToString();
                cueTextBox1_Vozrast.Text = row.Cells[3].Value.ToString();
                cueTextBox4_Doljnost.Text = row.Cells[4].Value.ToString();
            }
        }

        private void pictureBox2_Refresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
        }

        private void yt_Button1_New_Click(object sender, EventArgs e)
        {
            Add_Form add_Form = new Add_Form();
            add_Form.Show();
        }

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Sotrudniki where concat (Id_Sotrudniki, FIO_Sotrudnik, Gender, Vozrast,doljnost) like '%" + cueTextBox1_Poisk.Text +"%'";

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

            for(int index = 0; index < dataGridView1.Rows.Count;index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)

                    continue;

                if(rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Sotrudniki where Id_Sotrudniki = {id}";
                    var command = new SqlCommand(deleteQuery, DataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var Id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var FIO = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var Gender = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var Vozrast = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var doljnost = dataGridView1.Rows[index].Cells[4].Value.ToString();

                    var changeQuery = $"update Sotrudniki set FIO_Sotrudnik = '{FIO}', Gender = '{Gender}', Vozrast = '{Vozrast}', doljnost = '{doljnost}' where Id_Sotrudniki = '{Id}'";

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

        private void Is_Admin()
        {
            yt_Button1_New.Enabled = _user.Is_Admin;
            yt_Button2_Delete.Enabled = _user.Is_Admin;
            yt_Button3_Izmena.Enabled = _user.Is_Admin;
            yt_Button4_Save.Enabled = _user.Is_Admin;
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
            var Gender = cueTextBox3_Gender.Text;
            int Vozrast;
            var Doljnost = cueTextBox4_Doljnost.Text;

            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if(int.TryParse(cueTextBox1_Vozrast.Text, out Vozrast))
                {
                    dataGridView1.Rows[selectedRowIndex].SetValues(Id, FIO, Gender, Vozrast, Doljnost);
                    dataGridView1.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
                }
                else
                {
                    MessageBox.Show("Поле возраст должено иметь числовой формат");
                }
            }
        }
        private void yt_Button3_Izmena_Click(object sender, EventArgs e)
        {
            Change();
            clear_Fields();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            Form1.Show();
            this.Hide();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            Search2(dataGridView1);
        }
        private void Search2(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Sotrudniki where concat (Id_Sotrudniki, FIO_Sotrudnik, Gender, Vozrast,doljnost) like '%" + toolStripTextBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, DataBase.getConnection());

            DataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        }

        private void запрос4ВыборкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

