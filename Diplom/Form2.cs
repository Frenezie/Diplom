using Diplom;
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
    public partial class Form2 : Form
    {
        DataBase dataBase = new DataBase();
        public Form2()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection()
        {
            "Админ",
            "Секретарь",
        };
            cueTextBox1.AutoCompleteCustomSource = source;
            cueTextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cueTextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cueTextBox2.UseSystemPasswordChar = true;
            pictureBox1.Visible = false;
            cueTextBox1.MaxLength = 50;
            cueTextBox2.MaxLength = 50;
            
        }

        private void cueTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void yt_Button1_Click(object sender, EventArgs e)
        {
            var Login_User = cueTextBox1.Text;
            var PasswordUser = cueTextBox2.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            String querystring = $"select Id, Login_user, Password_user,Is_Admin from Register where Login_user = '{Login_User}' and Password_User = '{PasswordUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                var user = new checkUser(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]));
                MessageBox.Show("Вы успешно зашли", "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 Form1 = new Form1(user);
                this.Hide();
                Form1.ShowDialog();
            }
            else
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cueTextBox2.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox1.Visible = true;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cueTextBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox1.Visible = false;
        }
    }
}
