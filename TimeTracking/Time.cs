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
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Agni\Desktop\TimeTracking\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
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
            secure_form secure = new secure_form();
            secure.ShowDialog();
            if (secure.s()==true)
            {
                // Albin ktau shkruje funksjonin per add hours




                //
                MessageBox.Show("added");
            }
            else
            {
                MessageBox.Show("not added");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Menu menu = new Menu();
            menu.ShowDialog();        
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

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }        
        private void button3_Click_1(object sender, EventArgs e)
        {          
            secure_form secure = new secure_form();
            secure.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
