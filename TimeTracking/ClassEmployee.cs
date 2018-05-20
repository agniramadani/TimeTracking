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
        private string name;
        private string surname;
        private string city;
        private string country;
        private double salary;
        private bool active;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                this.surname = value;
            }
        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                this.city = value;
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                this.country = value;
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                this.salary = value;
            }
        }

        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                this.active = value;
            }
        }

        public void hireEmployee()
        {
            //Jasir mund ta fajtish ktau databasen
            //kije variabla id(int), name(string), surname(string), city(string),country(string), salary(double), active(bool)

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dc\Documents\EmployeeData.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand();
            con.Open();
            cmd.CommandText = "insert into Employees (id,name,surname,city,country,salary,active) values " +
                "('" + id + "','" + name + "','" + surname + "','" + city + "','" + country + "','" + salary + "','" + active + "')";

            //Deri ktau
            StreamWriter newEmployee = new StreamWriter(Application.StartupPath+"//Employees//"+id+" "+name+".txt");
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