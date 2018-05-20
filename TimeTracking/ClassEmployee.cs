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
        private int id { get; set; }
        private string name { get; set; }
        private string surname { get; set; }
        private string city { get; set; }
        private string country { get; set; }
        private double salary { get; set; }
        private bool active { get; set; }

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


            StreamWriter newEmployee = new StreamWriter(Application.StartupPath + "//Employees//" + id + " " + name + ".txt");
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