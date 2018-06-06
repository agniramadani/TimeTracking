﻿using System;
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
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        ClassEmployee emp = new ClassEmployee();
        int i = 0;
 
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
            if (i == 0)
            {              
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Enter hours");
                    }
                    else if(comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Select one employee");
                    }
                    else if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
                    {
                        MessageBox.Show("Please enter only numbers.");
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    }
                    else if (!emp.isDateRepeated(dateTimePicker1, comboBox1.Text))
                    {
                        secure_form secure = new secure_form();
                        secure.ShowDialog();
                        if (secure.s() == true)
                        {
                            //Add hours
                            AddHours();
                        }
                        else
                        {
                            MessageBox.Show("Hours not added!");
                        }
                    }
                    else
                        MessageBox.Show("Hours for " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " are already set!");
            }
            else
            {
                if (!emp.isDateRepeated(dateTimePicker1, comboBox1.Text))
                {
                    //Add hours 
                    AddHours();
                    MessageBox.Show("Added");
                }
                else
                    MessageBox.Show("Hours for " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " are already set!");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //ADD HOURS FUNCTION
        private void AddHoursFunction()
        {

            string id = Regex.Replace(comboBox1.Text, "[^0-9.]", "");
            string name = Regex.Replace(comboBox1.Text, @"[\d-]", string.Empty);
            name = Regex.Replace(name, @"\s+", "");
            cmd.Connection = con;
            con.Open();
            int hours = int.Parse(textBox1.Text);
            cmd.CommandText = "update Employees set hours += '" + hours + "'where ID='" + id + "'";

            MessageBox.Show("Hours for " + name + " are successfully updated!");
            cmd.ExecuteNonQuery();
            con.Close();
            writeToFile();

        }

        private void AddHours()
        {
            int value;

            if (int.TryParse(textBox1.Text, out value) && textBox1.Text != "")
            {
                //USING ADD HOURS FUNCTION
                AddHoursFunction();
                i++;
            }
            else
            {
                MessageBox.Show("Please enter a valid numerical value!");
            }


        }
    }
}
