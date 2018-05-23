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
        ClassEmployee emp = new ClassEmployee();

        public HireEmployee()
        {
            InitializeComponent();
            StreamReader readNrEmployeesFile = new StreamReader(Application.StartupPath + "//Employees//NrEmployeesFile.txt");
            textBox1.Text = readNrEmployeesFile.ReadToEnd();
            readNrEmployeesFile.Close();
            emp.inactiveEmployees(comboBox1);
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
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            emp.restoreEmployee(comboBox1);
            emp.inactiveEmployees(comboBox1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
