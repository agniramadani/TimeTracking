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
    public partial class secure_form : Form
    {
        // variabla n fillim osht 0 nese bohet 1 dmth useri osht logau
        int a=0;
        // Ki funksion osht per bo check nese useri logohet (kthen true) ene mbrapa useri mund t boje ndyshime
        public bool s()
        {
            if (a==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        DataTable dt = new DataTable();        
        public secure_form()
        {
            InitializeComponent();
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void secure_form_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from Login where Name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                //kur logohet variabla bohet 1
                a = 1;
                this.Hide();
            }
            else if (textBox1.Text == "" | textBox2.Text == "")
            {
                MessageBox.Show("Please enter you username and password");
                textBox1.Clear();
                textBox2.Clear();
            }

            else MessageBox.Show("Incorrect username/passowrd!");
            textBox1.Clear();
            textBox2.Clear();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
