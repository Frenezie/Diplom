using Diplom;
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

namespace Diplom
{
    public partial class Add_Form4 : Form
    {
        DataBase DataBase = new DataBase();
        public Add_Form4()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Add_Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.openConnection();

            var FIO = cueTextBox2.Text;
            var adrs = cueTextBox3.Text;
            var vid = cueTextBox4.Text;
            var cvet = cueTextBox5.Text;
            var nmer = cueTextBox6.Text;
            var FP = cueTextBox1.Text;
            int stoim;
            var kolvo = cueTextBox8.Text;
            var itogo = cueTextBox9.Text;

            if (int.TryParse(cueTextBox7.Text, out stoim))
            {

                var addQuery = $"insert into Klient (FIO, Adress,VidOtdelMat,Cvet,Phone,FIO_Sotrudnik,Stoimost,Kolichestvo,Itogo) values ('{FIO}','{adrs}','{vid}','{cvet}','{nmer}','{FP}','{stoim}','{kolvo}','{itogo}')";

                var command = new SqlCommand(addQuery, DataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана", "Запись создана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поле стоимость должно иметь числовой формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataBase.ClosedConnection();
        }
    }
}