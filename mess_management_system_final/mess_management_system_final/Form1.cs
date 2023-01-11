                           using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace mess_management_system_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string myconnection = " datasource = localhost; username = root;password=;database = Mess_management_system";
                MySqlConnection myConn = new MySqlConnection(myconnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from Mess_management_system.userlogin where username = '" + this.textBox1.Text + "' and password = '" + this.textBox2.Text + "';", myConn);
                MySqlDataReader myReader;

                myConn.Open();
                myReader = SelectCommand.ExecuteReader();
                int count = 0;

                while (myReader.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    this.Hide();
                    detailsformui admincontrol = new detailsformui();
                    admincontrol.ShowDialog();

                }
                else if (count > 1)
                {
                    MessageBox.Show("deplicate username and password");
                }
                else
                {
                    MessageBox.Show("username and password aren't correct.. please try again");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            do_checked();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            do_checked();
        }
        private void do_checked()
        {
            Adminbutton.Enabled = checkBox1.Checked;
        }

        private void Adminbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminloginform adminloginform = new adminloginform();
            adminloginform.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
                Application.Exit();
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
                WindowState = FormWindowState.Minimized;
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
