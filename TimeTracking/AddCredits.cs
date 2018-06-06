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
    public partial class AddCredits : Form
    {
        ClassEmployee emp = new ClassEmployee();
        bool i = false;
        public AddCredits()
        {
            InitializeComponent();
            emp.loadEmployeeList(comboBox1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Select one employee");
            }
            else if(textBox1.Text == "")
            {
                MessageBox.Show("Write credits");
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            else if(!i)
            {
                secure_form secure = new secure_form();
                secure.ShowDialog();
                if (secure.s() == true)
                {
                    //Ketu duhet te krijojme nje funksion per add credits 
                    //
                    //
                    //
                    //
                    //


                    //Kjo variabel ritet nese logohemi me sukses edhe nese perseri bejme add credits nuk na kerkon secure formen
                    //nese heren e pare jemi logu ather te dyten nuk ka nevoj te logohemi perseri
                    i = true;

                    MessageBox.Show("Credits Added");
                }
                else
                {
                    MessageBox.Show("Credits not added!");
                }               
            }
            else
            {
                //Funksion per add credits 
                //
                //
                //
                //
                //

                MessageBox.Show("Credits Added");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }

        private void AddCredits_Load(object sender, EventArgs e)
        {

        }
    }
}