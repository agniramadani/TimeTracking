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
using System.IO;

namespace TimeTracking
{
    public partial class Time : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        ClassEmployee emp = new ClassEmployee();
        public Time()
        {
            InitializeComponent();
            emp.loadEmployeeList(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            con.Open();
            int hours = int.Parse(textBox1.Text);
            cmd.CommandText="update Employees set hours += '"+hours+"'where name='"+comboBox1.Text+"'";
            MessageBox.Show("Hours for " + comboBox1.Text + " are successfully updated!");
            cmd.ExecuteNonQuery();
            con.Close();
            writeToFile();
            emp.loadEmployeeList(comboBox1);
            comboBox1.Text = "Employees...";

         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void writeToFile()
        {
            string employeePath = Application.StartupPath + "//Employees//" + comboBox1.Text + ".txt";
            string dataToWrite = dateTimePicker1.Value.ToString("dd/MM/yyyy") +" - "+ int.Parse(textBox1.Text);
            StreamWriter writeEmployee = new StreamWriter(employeePath, true);
            writeEmployee.WriteLine(dataToWrite);
            writeEmployee.Close(); 
        }

        private void Time_Load(object sender, EventArgs e)
        {

        }
    }
}
