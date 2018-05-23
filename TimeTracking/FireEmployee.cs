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
    public partial class FireEmployee : Form
    {
        ClassEmployee emp = new ClassEmployee();

        public FireEmployee()
        {
            InitializeComponent();
            emp.loadEmployeeList(comboBox1);
        }

        private void FireEmployee_Load(object sender, EventArgs e)
        {
          
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            emp.fireEmployee(comboBox1);
            emp.loadEmployeeList(comboBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp.employeeInfo(comboBox1.Text, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
        }
    }
}
