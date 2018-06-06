using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimeTracking
{
    public partial class Login : Form
    {
       
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        DataTable dt = new DataTable();       
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {   
                string query = "select * from Login where Name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Login approved!");
                    Menu menu = new Menu();
                    menu.Show();
                    this.Hide();

                }
                else if (textBox1.Text == "" | textBox2.Text == "")
                {
                    MessageBox.Show("Please enter you username and password");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                else
                {
                    MessageBox.Show("Incorrect username/passowrd!");
                    textBox1.Clear();
                    textBox2.Clear();
                }              
        }   
    }
}
