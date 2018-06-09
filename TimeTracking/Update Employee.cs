using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace TimeTracking
{
    public partial class UpdateEmployee : Form
    {
        ClassEmployee emp = new ClassEmployee();
        secure_form secure = new secure_form();
        Menu menu = new Menu();
        bool i = false;
        bool save = true;
        public UpdateEmployee()
        {
            InitializeComponent();
            emp.loadEmployeeList(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            emp.employeeInfo(comboBox1.Text, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
            save = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
                MessageBox.Show("Select one employee");
            
            else if (textBox1.Text == "")
                MessageBox.Show("Write credits");
            
            else if (!i)
            {
                secure.ShowDialog();
                if (secure.s() == true)
                {
                    emp.updateEmployee(comboBox1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
                    emp.loadEmployeeList(comboBox1);
                    i = true;
                    save = true;
                }
                else
                    MessageBox.Show("Employee isn't updated successfully!");
            }

            else
            {
                emp.updateEmployee(comboBox1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
                emp.loadEmployeeList(comboBox1);
                i = true;
                save = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!save)
            {
                DialogResult dr = MessageBox.Show("Do you want to save changes made to " + textBox2.Text + " ?",
                    "", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        if (!i)
                        {
                            secure_form secure = new secure_form();
                            secure.ShowDialog();
                            if (secure.s() == true)
                            {
                                emp.updateEmployee(comboBox1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
                                emp.loadEmployeeList(comboBox1);
                                i = true;
                            }
                        }
                        else
                        {
                            emp.updateEmployee(comboBox1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6);
                            emp.loadEmployeeList(comboBox1);
                        }
                        this.Hide();
                        menu.Show();
                        break;
                    case DialogResult.No:
                        this.Hide();
                        menu.Show();
                        break;
                }
            }
            else
            {
                this.Hide();
                menu.Show();
            }
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}