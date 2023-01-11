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
    public partial class detailsformui : Form
    {
        MySqlConnection Connection = new MySqlConnection("datasource = localhost; port = 3306; Initial Catalog = 'Mess_management_system'; username = root; password=");
        //MySqlCommand command;
        MySqlCommand commandd;
        MySqlCommand commandbc;
        MySqlCommand commandlunch2;
        MySqlCommand commanddinner2;
        //MySqlDataAdapter adapter;
        MySqlDataAdapter adapterr;
        MySqlDataAdapter adapterbc;
        MySqlDataAdapter adapterlunch2;
        MySqlDataAdapter adapterdinner2;
        //DataTable table;
        DataTable tablee;
        DataTable tablebc;
        DataTable tablebc2;
        DataTable tablebc4;
        public detailsformui()
        {
            InitializeComponent();
        }

        


        MySqlConnection con = new MySqlConnection("datasource = localhost; port = 3306; Initial Catalog = 'Mess_management_system'; username = root; password=");

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void backbutton_Click(object sender, EventArgs e)
        {

        }
        private void BTN_SEARCH_Click(object sender, EventArgs e)
        {

        }

        private void BTN_SEARCH_Click_1(object sender, EventArgs e)
        {
            string valueToSearch = textBoxValueToSearch.Text.ToString();
            searchData(valueToSearch);
            textBoxValueToSearch.Text = "";

            //breakfastcosttextbox.Text = "";
            //dinnertextbox.Text = "";
            //lunchtectbox.Text = "";
            //breakfasttextbox.Text = "";


        }

        

        private void detailsformui_Load(object sender, EventArgs e)
        {

            searchData("");
        }


        public void searchData(string valueToSearch)
        {

            dgv1.AllowUserToAddRows = false;

            string query = "SELECT `Id`, `Name`, `Gender`, `Mobile`, `Permanent_Address`, `Occupation`, `Room_Number`, `Nick_name`, `Gurdian_Mobile` FROM add_member WHERE CONCAT(`Id`, `Name`, `Gender`, `Mobile`, `Permanent_Address`, `Occupation`, `Room_Number`, `Nick_name`, `Gurdian_Mobile`) like '%" + valueToSearch + "%'";

            string sumbreakfast = "SELECT SUM(Market_cost) as Total_Breakfast_Cost FROM cost ";
            string sumfastcost = " SELECT SUM(Break_Fast) as Total_Breakfast FROM meal WHERE meal.Meal_Id ";
            string sumlunchcost = " SELECT SUM(Lunch) as Total_Lunch FROM meal WHERE meal.Meal_Id ";
            string sumdinnercost = " SELECT SUM(Dinner) as Total_Dinner FROM meal WHERE meal.Meal_Id ";

            MySqlCommand command = new MySqlCommand(query, Connection);
         commandd = new MySqlCommand(sumbreakfast, Connection);
            commandbc = new MySqlCommand(sumfastcost, Connection);
            commandlunch2 = new MySqlCommand(sumlunchcost, Connection);
            commanddinner2 = new MySqlCommand(sumdinnercost, Connection);

         

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapterr = new MySqlDataAdapter(commandd);
            adapterbc = new MySqlDataAdapter(commandbc);
            adapterlunch2 = new MySqlDataAdapter(commandlunch2);
            adapterdinner2 = new MySqlDataAdapter(commanddinner2);


            //testbox.Text = adapterr.ToString();

            DataTable table = new DataTable();

            tablee = new DataTable();
            tablebc = new DataTable();
            tablebc2 = new DataTable();
            tablebc4 = new DataTable();

            


            adapter.Fill(table);
            adapterr.Fill(tablee);
            adapterbc.Fill(tablebc);
            adapterlunch2.Fill(tablebc2);
            adapterdinner2.Fill(tablebc4);

            //testbox.Text = tablee.ToString();

            dataGridView1.DataSource = table;
            dgv1.DataSource = tablee;
            dgv2.DataSource = tablebc;

            dataGridView3.DataSource = tablebc2;

           
            dataGridView5.DataSource = tablebc4;






            dgv1.AllowUserToAddRows = false;
            dgv2.AllowUserToAddRows = false;



            double a, b, d, f;

            a = double.Parse(dgv1.Rows[0].Cells[0].Value.ToString());
            b = double.Parse(dgv2.Rows[0].Cells[0].Value.ToString());


           
            d = double.Parse(dataGridView3.Rows[0].Cells[0].Value.ToString());

            
            f = double.Parse(dataGridView5.Rows[0].Cells[0].Value.ToString());






            breakfastcosttextbox.Text = a.ToString();
            breakfasttextbox.Text = b.ToString();

            
            lunchtectbox.Text = d.ToString();

            dinnertextbox.Text = f.ToString();



        }

      



        public void Idbutton_Click(object sender, EventArgs e)
        {
            

            try
            {
                string myconnection1 = " datasource = localhost; username = root;password=;database = Mess_management_system";
                MySqlConnection myConn1 = new MySqlConnection(myconnection1);
                MySqlCommand SelectCommand1 = new MySqlCommand("select * from Mess_management_system.add_member where Id = '" + this.idtextbox.Text + "';", myConn1);
                MySqlDataReader myReader1;
                
                myConn1.Open();
                myReader1 = SelectCommand1.ExecuteReader();
                int count = 0;

                while (myReader1.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {

                   

                    MySqlDataAdapter asdf = new MySqlDataAdapter(" SELECT SUM(Break_Fast) as Person_Break_Fast FROM meal WHERE meal.Id='" + idtextbox.Text + "' ", con);
                    DataTable ss = new DataTable();
                    asdf.Fill(ss);


                    dgv3.DataSource = ss;
                    double idm = 0;
                    idm = double.Parse(dgv3.Rows[0].Cells[0].Value.ToString());
                    idmtextbox.Text = idm.ToString();
                  
                    MySqlDataAdapter asdflunch = new MySqlDataAdapter(" SELECT SUM(Lunch) as Person_Lunch FROM meal WHERE meal.Id='" + idtextbox.Text + "' ", con);
                    DataTable sslunch = new DataTable();
                    asdflunch.Fill(sslunch);
                    dataGridView6.DataSource = sslunch;
                    double idmlunch;
                    idmlunch = double.Parse(dataGridView6.Rows[0].Cells[0].Value.ToString());
                    lunchtextbox.Text = idmlunch.ToString();



                  
                    MySqlDataAdapter asdfdinner = new MySqlDataAdapter(" SELECT SUM(Dinner)  as Person_Dinner FROM meal WHERE meal.Id='" + idtextbox.Text + "' ", con);
                    DataTable ssdinner = new DataTable();
                    asdfdinner.Fill(ssdinner);
                    dataGridView8.DataSource = ssdinner;
                    double idmdinner;
                    idmdinner = double.Parse(dataGridView8.Rows[0].Cells[0].Value.ToString());
                    dnrtxtbox.Text = idmdinner.ToString();
                    MySqlDataAdapter asdf1 = new MySqlDataAdapter(" SELECT SUM(deposite_account) as Total_Deposite_account FROM account WHERE account.Id ='" + idtextbox.Text + "' ", con);
                    DataTable ss1 = new DataTable();
                    asdf1.Fill(ss1);




                    dgv4.DataSource = ss1;



                    double idm1 = 0, act=0, ipmdinner=0, ipmlunch=0, totalbreakfast=0, totallunch=0, totaldinner=0;
                    idm1 = double.Parse(dgv4.Rows[0].Cells[0].Value.ToString());

                    accounttextbox.Text = idm1.ToString();



                    double totalcost = Convert.ToDouble(breakfastcosttextbox.Text);
                     totalbreakfast = Convert.ToDouble(breakfasttextbox.Text);
                    double ipm = Convert.ToDouble(idmtextbox.Text);


                    
                     totallunch = Convert.ToDouble(lunchtectbox.Text);
                    ipmlunch = Convert.ToDouble(lunchtextbox.Text);

                 
                    totaldinner = Convert.ToDouble(dinnertextbox.Text);
                   ipmdinner = Convert.ToDouble(dnrtxtbox.Text);




                     act = Convert.ToDouble(accounttextbox.Text);

                    double result = act - ((ipm + ipmdinner + ipmlunch) * (totalcost / (totalbreakfast + totallunch + totaldinner)));
                    if (result > 0)
                    {
                        resulttextbox.Text = "Receivable Amount: " + result.ToString();

                    }
                    else
                    {
                        resulttextbox.Text = "Payable :" + result.ToString();
                    }

                }

                else
                {
                    MessageBox.Show(" Please Enter vallied Id Number ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            idtextbox.Text = "";
            
        }

        private void brkfstcalculationbutton_Click(object sender, EventArgs e)
        {





        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 ff = new Form1();
            ff.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void idmtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void resulttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void idtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void accounttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dinnercosttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dinnertextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dnrtxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lunchtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lunchtectbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lunchcosttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void breakfasttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void breakfastcosttextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxValueToSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      
    }
}