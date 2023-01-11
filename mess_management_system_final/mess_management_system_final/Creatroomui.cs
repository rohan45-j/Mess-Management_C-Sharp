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
    public partial class Creatroomui : Form
    {
        string connectionstring = "datasource = localhost; username = root;password=; database = Mess_management_system";

        public Creatroomui()
        {
            InitializeComponent();
        }

        private void creatroombutton_Click(object sender, EventArgs e)
        {
            string conectstring = "datasource = localhost; username = root;password=; database = Mess_management_system";

            MySqlConnection connectionn = new MySqlConnection(conectstring);
            string creatroom_query = " INSERT INTO creatroom VALUES ('" + roomidtextbox.Text + "','" + roomnametextbox.Text + "','" + renttextbox.Text + "')";
            MySqlCommand creatroomcommannd = new MySqlCommand(creatroom_query, connectionn);
            connectionn.Open();
            creatroomcommannd.ExecuteNonQuery();
            connectionn.Close();
            MessageBox.Show("Save Succesfully");
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
           

        }

        private void greadviewbutton_Click(object sender, EventArgs e)
        {
            using ( MySqlConnection sqlcon =new MySqlConnection(connectionstring))
            {
                sqlcon.Open();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(" SELECT * FROM creatroom ", sqlcon);
                DataTable DTBL = new DataTable();
                sqlda.Fill(DTBL);
                dgv1.DataSource = DTBL;
                
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            admincontrolui frm = new admincontrolui();
            frm.Show();
        }
    }
}
