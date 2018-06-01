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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CalculateSalary calculateSalary = new CalculateSalary();
            calculateSalary.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            Employees employees = new Employees();
            employees.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HireEmployee h = new HireEmployee();
            h.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Time time = new Time();
           time.Show();
           
           this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FireEmployee fireEmp = new FireEmployee();
            fireEmp.Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddCredits add = new AddCredits();
            add.Show();
            this.Hide();
        }
    }
}