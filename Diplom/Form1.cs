﻿using Diplom.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Form1 : Form
    {
        private readonly checkUser _user;
        DataBase dataBase = new DataBase();
        public Form1(checkUser user)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _user = user;
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = $"Пользователь: {_user.Login_User}\nДоступные права: {_user.Status}\n";
            if(_user.Status == "Админ")
            {
                pictureBox3.Hide();
                pictureBox2.Show();
            }
            else
            {
                pictureBox2.Hide();
                pictureBox3.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void yt_Button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены что хотите выйти", "Выход", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 Form1 = new Form1(_user);
                this.Close();
                Form2 Form2 = new Form2();
                Form2.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
            
            }
        }

        private void yt_Button5_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            this.Hide();
            Klients Klients = new Klients(_user);
            Klients.Show();
        }

        private void yt_Button4_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            this.Hide();
            Sotrudniki Sotrudniki = new Sotrudniki(_user);
            Sotrudniki.Show();
        }

        private void yt_Button3_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            this.Hide();
            Sklad Sklad = new Sklad(_user);
            Sklad.Show();
        }

        private void yt_Button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            this.Hide();
            Cena Cena = new Cena(_user);
            Cena.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_Status_Click(object sender, EventArgs e)
        {

        }

        private void yt_Button6_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            this.Hide();
            Form3Test frm = new Form3Test(_user);
                frm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
