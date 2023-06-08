﻿using System;
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
    public partial class Add_Form2 : Form
    {
        DataBase DataBase = new DataBase();
        public Add_Form2()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Add_Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.openConnection();

            var vidmat = cueTextBox3.Text;
            var cvet = cueTextBox4.Text;
            int stoim;
            var ost = cueTextBox1.Text;

            if (int.TryParse(cueTextBox5.Text, out stoim))
            {

                var addQuery = $"insert into Stoimost (VidOtdelMat,Cvet,Stoimost, Ostatok) values ('{vidmat}','{cvet}','{stoim}','{ost}')";

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