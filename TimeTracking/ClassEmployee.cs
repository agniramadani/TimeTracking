using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace TimeTracking
{
    class ClassEmployee
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader drd;

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        private bool active;
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public void hireEmployee(int a, string b, string c, string d, string e, double f)
        {
            id = a;
            name = b;
            surname = c;
            city = d;
            country = e;
            salary = f;
            active = true;

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into Employees (id,name,surname,city,country,salary,hours,active) values " +
                "('" + ID + "','" + Name + "','" + Surname + "','" + City + "','" + Country + "','" + Salary + "','" + 0 + "','" + active + "')";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();


            StreamWriter newEmployee = new StreamWriter(Application.StartupPath + "//Employees//"+ name + ".txt");
            newEmployee.WriteLine("Date         Hours");
            newEmployee.Close();
            string nrEmployeesPath = Application.StartupPath + "//Employees//NrEmployeesFile.txt";
            if (File.Exists(nrEmployeesPath))
            {
                File.Delete(nrEmployeesPath);
            }
            StreamWriter nrOfEmployeesFile = new StreamWriter(nrEmployeesPath);
            nrOfEmployeesFile.WriteLine(id + 1);
            nrOfEmployeesFile.Close();
        }

        //Merr si parameter emrin e puntorit dhe kthen nese eshte aktiv apo jo
        private bool activeEmp(string _name)
        {
            cmd.CommandText = "select * from Employees where name = '" + _name + "'";
            return Convert.ToBoolean(drd[6]);
        }

        //Lista e punetoreve aktiv
        public void loadEmployeeList(ComboBox comboBox1)
        {
            comboBox1.Text = "Employees...";
            cmd.Connection = con;
            comboBox1.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from Employees";
            drd = cmd.ExecuteReader();

            if (drd.HasRows)
                while (drd.Read())
                   if (activeEmp(drd[1].ToString()))
                      comboBox1.Items.Add(drd[1].ToString());
                
            con.Close();
        }

        //Lista e punetoreve jo aktiv
        public void inactiveEmployees(ComboBox comboBox1)
        {
            comboBox1.Text = "Fired employees...";
            cmd.Connection = con;
            comboBox1.Items.Clear();
            con.Open();
            cmd.CommandText = "select * from Employees";
            drd = cmd.ExecuteReader();

            if (drd.HasRows)
                while (drd.Read())
                    if (!activeEmp(drd[1].ToString()))
                        comboBox1.Items.Add(drd[1].ToString());
                
            con.Close();
        }

        public void employeeInfo(string select, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6)
        {
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Employees where name = '"+select+"'";
            drd = cmd.ExecuteReader();
            if (drd.Read())
            {
                t1.Text = drd[0].ToString();
                t2.Text = select;
                t3.Text = drd[2].ToString();
                t4.Text = drd[3].ToString();
                t5.Text = drd[4].ToString();
                t6.Text = drd[5].ToString();
            }
            con.Close();

        }

        //Shkarkon nga puna nje punetor
        public void fireEmployee(ComboBox comboBox)
        {
            con.Open();
            cmd.CommandText = "update Employees set active = '" + false + "'where name='" + comboBox.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee " + comboBox.Text + " is fired!");
            comboBox.Text = "Employees...";
            con.Close();
        }

        //E rikthen ne pune nje punetor i cili eshte shkarkuar (joaktiv)
        public void restoreEmployee(ComboBox comboBox)
        {
            con.Open();
            cmd.CommandText = "update Employees set active = '" + true + "'where name='" + comboBox.Text + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee " + comboBox.Text + " is back!");
            comboBox.Text = "Fired employees...";
            con.Close();
        }
    }
}