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
using System.Text.RegularExpressions;

namespace TimeTracking
{
    
    public partial class Time : Form
    {
        ClassEmployee emp = new ClassEmployee();
        bool i = false;
 
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
            if (!i)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter hours");
                }
                else if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Select one employee");
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
                {
                    MessageBox.Show("Please enter only numbers.");
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                else if (emp.isDateRepeated(dateTimePicker1, comboBox1.Text))
                {
                    secure_form secure = new secure_form();
                    secure.ShowDialog();
                    if (secure.s() == true)
                    {
                        string dataToWrite = dateTimePicker1.Value.ToString("dd MM yyyy ") + int.Parse(textBox1.Text);
                        DialogResult dr = MessageBox.Show("Do you want to replace hours?",
                          "Record for this date exists", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.Yes:
                                emp.ReplaceHours(dateTimePicker1, comboBox1.Text, dataToWrite);
                                break;
                            case DialogResult.No:
                                break;
                        }
                        i = true;
                    }
                }
                else
                {
                    secure_form secure = new secure_form();
                    secure.ShowDialog();
                    if (secure.s() == true)
                        AddHours();
                }
            }
            else
            {
                if (emp.isDateRepeated(dateTimePicker1, comboBox1.Text))
                {
                    string dataToWrite = dateTimePicker1.Value.ToString("dd MM yyyy ") + int.Parse(textBox1.Text);
                    DialogResult dr = MessageBox.Show("Do you want to replace hours?",
                      "", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            emp.ReplaceHours(dateTimePicker1,comboBox1.Text,dataToWrite);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                    AddHours();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i = false;
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void writeToFile()
        {
            string id = Regex.Replace(comboBox1.Text, "[^0-9.]", "");
            string name = Regex.Replace(comboBox1.Text, @"[\d-]", string.Empty);
            name = Regex.Replace(name, @"\s+", "");
         
            string employeePath = Application.StartupPath + "//Employees//" +id+" "+ name + ".txt";
            string dataToWrite = dateTimePicker1.Value.ToString("dd MM yyyy ") + int.Parse(textBox1.Text);
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddHours()
        {
            int value;

            if (int.TryParse(textBox1.Text, out value) && textBox1.Text != "")
            {
                string name = Regex.Replace(comboBox1.Text, @"[\d-]", string.Empty);
                name = Regex.Replace(name, @"\s+", "");
                MessageBox.Show("Hours for " + name + " are successfully updated!");
                writeToFile();
                i = true;
            }
            else
            {
                MessageBox.Show("Please enter a valid numerical value!");
            }


        }
    }
}
