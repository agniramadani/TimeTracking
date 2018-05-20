using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TimeTracking
{
    public partial class HireEmployee : Form
    {    
        public HireEmployee()
        {
            InitializeComponent();
            StreamReader readNrEmployeesFile = new StreamReader(Application.StartupPath + "//Employees//NrEmployeesFile.txt");
            textBox1.Text = readNrEmployeesFile.ReadToEnd();
            readNrEmployeesFile.Close();
        }

        private void HireEmployee_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            ClassEmployee newEmployee = new ClassEmployee();
            int a = int.Parse(textBox1.Text);
            newEmployee.hireEmployee(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, double.Parse(textBox6.Text));
            MessageBox.Show("Employee added!");
            textBox1.Text = (a+1).ToString();
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = "";
        }
    }
}
