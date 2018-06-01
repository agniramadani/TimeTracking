using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracking
{
    public partial class CalculateSalary : Form
    { 
   
       ClassEmployee emp = new ClassEmployee();
    public CalculateSalary()
    {
        InitializeComponent();
        emp.loadEmployeeList(comboBox1);
        label2.Hide();
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

        private void button1_Click_1(object sender, EventArgs e)
    {
         label2.Show();
         emp.calculateSalary(comboBox1.Text, comboBox2.Text, comboBox3.Text, textBox1);
         label2.Text = "Thes salary for " + comboBox1.Text + " for month " + comboBox2.Text + " " + comboBox3.Text + " is:";
         label2.Show();
    }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }
    }
}
