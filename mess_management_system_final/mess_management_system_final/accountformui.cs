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
    public partial class accountformui : Form
    {
        string connectionstring = @"datasource = localhost; username = root;password=; database = Mess_management_system;";
        
        public accountformui()
        {
            InitializeComponent();
        }

        
       

        public void addbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string conectstring = "datasource = localhost; username = root;password=; database = Mess_management_system";
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
                  
                    MySqlConnection connectionn = new MySqlConnection(conectstring);
                    string query = " INSERT INTO account  (Id,deposite_account  )  VALUES ('" + idtextbox.Text + "','" + accounttextbox.Text + "') ;";
                    MySqlCommand commannd = new MySqlCommand(query, connectionn);
                    connectionn.Open();

                    commannd.ExecuteNonQuery();
                    connectionn.Close();
                    MessageBox.Show("Add Succesfully");

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

        private void add2button_Click(object sender, EventArgs e)
        {


            try
            {

                string myconnection = " datasource = localhost; username = root;password=;database = Mess_management_system";
                MySqlConnection myConn = new MySqlConnection(myconnection);
                MySqlCommand SelectCommand = new MySqlCommand("select * from Mess_management_system.add_member where Id = '" + this.idtextboxid2.Text + "';", myConn);
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
                    string query = " INSERT INTO cost  (Id,Market_cost,Date)  VALUES ('" + idtextboxid2.Text + "','" + breakfastcostbox.Text + "','" + dateTimePicker1.Text + "') ;";
                    MySqlCommand commannd = new MySqlCommand(query, connectionn);
                    connectionn.Open();

                    commannd.ExecuteNonQuery();
                    connectionn.Close();
                    MessageBox.Show("Add Succesfully");

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

        private void backbutton_Click(object sender, EventArgs e)
        {
            
        }

        private void accountformui_Load(object sender, EventArgs e)
        {
            using ( MySqlConnection sqlcon = new MySqlConnection (connectionstring))
            {
                sqlcon.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(" SELECT Id , Name  FROM add_member", sqlcon);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                dataGridView1.DataSource = dtbl;
                sqlcon.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            admincontrolui frm = new admincontrolui();
            frm.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
