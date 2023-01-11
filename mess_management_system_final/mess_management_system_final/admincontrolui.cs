using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mess_management_system_final
{
    public partial class admincontrolui : Form
    {
        public admincontrolui()
        {
            InitializeComponent();
        }

        private void addmemberbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminformui adminformu = new adminformui();
            adminformu.ShowDialog();
        }

        private void creatroombutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Creatroomui creatroomform = new Creatroomui();
            creatroomform.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void mealbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            mealcontrolui frm = new mealcontrolui();
            frm.Show();
        }

        private void accountbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
           accountformui admincontrol = new accountformui();
            admincontrol.ShowDialog();
        }

        private void detailsbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            detailsformui admincontrol = new detailsformui();
            admincontrol.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           Form1 ff  = new Form1();
            ff.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1  ff =  new Form1();
            ff.Show();
        }
    }
}
