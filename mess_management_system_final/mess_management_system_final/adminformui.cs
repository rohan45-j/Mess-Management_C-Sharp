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
using System.IO;

namespace mess_management_system_final
{
    public partial class adminformui : Form
    {

        public adminformui()
        {


            InitializeComponent();

        }


        private void savebutton_Click(object sender, EventArgs e)
        {
            byte[] imagebt = null;
            FileStream fstream = new FileStream(this.textboximagepath.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fstream);
            imagebt = br.ReadBytes((int)fstream.Length);

            string conectstring = "datasource = localhost; username = root;password=; database = Mess_management_system";
            MySqlConnection connectionn = new MySqlConnection(conectstring);
            string query = " INSERT INTO add_member ( Name,Gender,Mobile,Permanent_Address,Occupation,Room_Number,Nick_name,Gurdian_Mobile,image  )  VALUES ('" + nametextbox.Text + "','" + comboBox1.Text + "','" + mobiletextbox.Text + "','" + addresstextbox.Text + "','" + occupationtextbox.Text + "' ,'" + roomidtextbox.Text + " ','" + neacknametextbox.Text + " ','" + gurdiantexbox.Text + " ',@IMG )";
            MySqlCommand commannd = new MySqlCommand(query, connectionn);
            connectionn.Open();
            commannd.Parameters.Add(new MySqlParameter("@IMG", imagebt));
            commannd.ExecuteNonQuery();
            connectionn.Close();
            MessageBox.Show("Save Succesfully");

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            admincontrolui frm = new admincontrolui();
            frm.Show();
        }

        private void adminformui_Load(object sender, EventArgs e)
        {

        }

        private void uploadimage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picLoc1 = dlg.FileName.ToString();
                textboximagepath.Text = picLoc1;
                uploadpicturebox.ImageLocation = picLoc1;
            }


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}