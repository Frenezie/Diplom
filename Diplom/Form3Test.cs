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
    public partial class Form3Test : Form
    {
        private readonly checkUser _user;
        public Form3Test(checkUser user)
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            _user = user;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3Test_Load(object sender, EventArgs e)
        {
            using(PredpriyatieEntities Pr = new PredpriyatieEntities())
            {
                bindingSource1.DataSource = Pr.VidOtdelMat.ToList();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1(_user);
            Form1.Show();
            this.Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
