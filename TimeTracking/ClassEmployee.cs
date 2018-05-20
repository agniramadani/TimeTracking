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
        public string Countru
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

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into Employees (id,name,surname,city,country,salary,hours,active) values " +
                "('" + id + "','" + name + "','" + surname + "','" + city + "','" + country + "','" + salary + "','" + 0 + "','" + active + "')";
            cmd.ExecuteNonQuery();
            cmd.Clone();
            con.Close();


            StreamWriter newEmployee = new StreamWriter(Application.StartupPath + "//Employees//"+ name + ".txt");
            newEmployee.WriteLine("Date          Hours");
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
    }
}