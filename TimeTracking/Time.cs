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

namespace TimeTracking
{
    public partial class Time : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader drd;
        public Time()
        {
            InitializeComponent();
            loadlist();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void loadlist()
        {
            cmd.Connection = con;
            comboBox1.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from Employees";
            drd = cmd.ExecuteReader();

            if (drd.HasRows)
                while (drd.Read())
                    comboBox1.Items.Add(drd[1].ToString());
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            int hours = int.Parse(textBox1.Text);
            cmd.CommandText="update Employees set hours += '"+hours+"'where name='"+comboBox1.Text+"'";
            MessageBox.Show("Hours for " + comboBox1.Text + " are successfully updated!");
            cmd.ExecuteNonQuery();
            con.Close();
            loadlist();
            comboBox1.Text = "Employees...";

            /* Albin lidhe me ato text filet ket bone per kit puntoret ta shkrune daten en sa or ka punu
             per cdo dit nrresht t ri, perdore daten pi ke kjo date and time picker. */
        }
    }
}
