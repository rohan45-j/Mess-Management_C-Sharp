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
    public partial class mealcontrolui : Form
    {
        string connectionstring = @"datasource = localhost; username = root;password=; database = Mess_management_system;";
        public mealcontrolui()
        {
            InitializeComponent();
        }

        private void dgv1_Click(object sender, EventArgs e)
        {

        }

        private void greadviewbutton_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection sqlcon = new MySqlConnection(connectionstring))
            {
                sqlcon.Open();
               
                 MySqlDataAdapter sqlda = new MySqlDataAdapter(" SELECT Id,Name FROM add_member ", sqlcon);
                DataTable DTBL = new DataTable();
                sqlda.Fill(DTBL);
                dgv1.DataSource = DTBL;

            }
        }

        private void addbutton_Click(object sender, EventArgs e)
        {


            try
                {
                string myconnection = " datasource = localhost; username = root;password=;database = Mess_management_system";
                MySqlConnection myConn = new MySqlConnection(myconnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from Mess_management_system.add_member where Id = '" + this.idtextbox.Text + "';", myConn);
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
                    string conectstring = "datasource = localhost; username = root;password=; database = Mess_management_system";
                    MySqlConnection connectionn = new MySqlConnection(conectstring);
                    string query = " INSERT INTO meal  (Break_Fast,lunch,Dinner,Id ,Date  )  VALUES ('" + breakfastbutton.Text + "','" + lunchtextbox.Text + "','" + ninnertextbox.Text + "','" + idtextbox.Text + "','" + dateTimePicker1.Text + "') ;";
                    MySqlCommand commannd = new MySqlCommand(query, connectionn);
                    connectionn.Open();

                    commannd.ExecuteNonQuery();
                    connectionn.Close();
                    MessageBox.Show("Save Succesfully");

                }
               
                else
                {
                    MessageBox.Show("Please Enter Correct Id");
                }
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void breakfastbutton_TextChanged(object sender, EventArgs e)
        {

        }

        private void mealback_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            admincontrolui frm = new admincontrolui();
            frm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void idtextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
