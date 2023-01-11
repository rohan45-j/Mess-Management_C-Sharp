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
    public partial class adminloginform : Form
    {
        public adminloginform()
        {
            InitializeComponent();
            passwordtextbox.PasswordChar = '*';
           passwordtextbox.MaxLength = 10;
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
        
             try
                {
                  string myconnection = " datasource = localhost; username = root;password=;database = Mess_management_system";
                MySqlConnection myConn = new MySqlConnection(myconnection);
                    MySqlCommand SelectCommand = new MySqlCommand("select * from Mess_management_system.logintable where User_name = '" + this.usernametextbox.Text + "' and pin = '" + this.passwordtextbox.Text + "';", myConn);
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
                    admincontrolui admincontrol = new admincontrolui();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
