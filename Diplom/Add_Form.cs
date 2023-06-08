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
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Text;

namespace Diplom
{
    public partial class Add_Form : Form
    {
        DataBase DataBase = new DataBase();

        public Add_Form()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Add_Form_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.openConnection();

            var FIO = cueTextBox2.Text;
            var Gender = cueTextBox3.Text;
            int Vozrast;
            var Doljnost = cueTextBox5.Text;

            if(int.TryParse(cueTextBox4.Text, out Vozrast))
            {

                var addQuery = $"insert into Sotrudniki (FIO_Sotrudnik, Gender, Vozrast, doljnost) values ('{FIO}','{Gender}', '{Vozrast}','{Doljnost}')";

                var command = new SqlCommand(addQuery, DataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана", "Запись создана", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поле Возраст должно иметь числовой формат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            DataBase.ClosedConnection();
        }
    }
}
