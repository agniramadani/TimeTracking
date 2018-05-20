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
    public partial class Employees : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader drd;

        public Employees()
        {
            InitializeComponent();
            loadlist();
        }
       // private classEmployees employees[50];


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void Employees_Load(object sender, EventArgs e)
        {

        }
        private void loadlist()
        {
            cmd.Connection = con;
            comboBox1.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from Employees";
            drd = cmd.ExecuteReader();

            if (drd.HasRows)
                while (drd.Read())
                    comboBox1.Items.Add(drd[1].ToString());
            con.Close();
        }
    }
}
