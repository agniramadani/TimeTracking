using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


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
            b = Regex.Replace(b, @"[\d-]", string.Empty);
            name = Regex.Replace(b, @"\s+", "");
            surname = c;
            city = d;
            country = e;
            salary = f;
            active = true;

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "insert into Employees (id,name,surname,city,country,salary,active) values " +
                "('" + ID + "','" + Name + "','" + Surname + "','" + City + "','" + Country + "','" + Salary + "','" + active + "')";
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
                      comboBox1.Items.Add(drd[0].ToString() + " " + drd[1].ToString());
                
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
                        comboBox1.Items.Add(drd[0].ToString() + " " + drd[1].ToString());
                
            con.Close();
        }

        public void employeeInfo(string select, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6)
        {
            string idna = Regex.Replace(select, "[^0-9.]", "");
            string _name = Regex.Replace(select, @"[\d-]", string.Empty);
            _name = Regex.Replace(_name, @"\s+", "");
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Employees where ID = '"+idna+"'";
            drd = cmd.ExecuteReader();
            if (drd.Read())
            {
                t1.Text = drd[0].ToString();
                t2.Text = _name;
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
            string idna = Regex.Replace(comboBox.Text, "[^0-9.]", "");
            string _name = Regex.Replace(comboBox.Text, @"[\d-]", string.Empty);
            _name = Regex.Replace(_name, @"\s+", "");
            con.Open();
            cmd.CommandText = "update Employees set active = '" + false + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee " + _name + " is fired!");
            comboBox.Text = "Employees...";
            con.Close();
        }

        //E rikthen ne pune nje punetor i cili eshte shkarkuar (joaktiv)
        public void restoreEmployee(ComboBox comboBox)
        {
            string idna = Regex.Replace(comboBox.Text, "[^0-9.]", "");
            con.Open();
            cmd.CommandText = "update Employees set active = '" + true + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee " + comboBox.Text + " is back!");
            comboBox.Text = "Fired employees...";
            con.Close();
        }

        private int monthConvert(string month)
        {
            if (month == "January")
            {
                return 1;
            }
            else if (month == "February")
            {
                return 2;
            }
            else if (month == "March")
            {
                return 3;
            }
            else if (month == "Aprill")
                return 4;
            else if (month == "May")
                return 5;
            else if (month == "June")
                return 6;
            else if (month == "July")
                return 7;
            else if (month == "August")
                return 8;
            else if (month == "September")
                return 9;
            else if (month == "Octomber")
                return 10;
            else if (month == "November")
                return 11;
            else
                return 12;
        }

        public bool isDateRepeated(DateTimePicker dt, string _name)
        {
            StreamReader empSalary = new StreamReader(path: Application.StartupPath + "//Employees//" + _name + ".txt");
            string line;
            string date = "";
            while ((line = empSalary.ReadLine()) != null && date != dt.Value.ToString("dd MM yyyy "))
            {
                date = line.Substring(0, 11);
            }
            empSalary.Close();
            if (date == dt.Value.ToString("dd MM yyyy "))
                return true;
            else return false;
        }

        public void calculateSalary(string _name, string _month, string _year, TextBox salaryTextBox)
        {
            string idna = Regex.Replace(_name, "[^0-9.]", "");
            string _salaryValue = salary.ToString();
           

            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select * from Employees where ID = '" + idna + "'";
            drd = cmd.ExecuteReader();
            if (drd.Read())
            {
                idna = drd[0].ToString();
                _salaryValue = drd[5].ToString();
            }
            con.Close();

            StreamReader employeesSalary = new StreamReader(path: Application.StartupPath + "//Employees//" + _name + ".txt");
            string line;
            int hoursPerMonth = 0;
            while ((line = employeesSalary.ReadLine()) != null)
            {
                string[] words = line.Split();
                string day = words[0];
                string month = words[1];
                string year = words[2];
                string hours = words[3];
                int _dayFromFile = int.Parse(day);
                int _monthFromFile = int.Parse(month);
                int _yearFromFile = int.Parse(year);
                int _hoursFromFile = int.Parse(hours);

                if (_monthFromFile == monthConvert(_month) && _yearFromFile == int.Parse(_year))
                {
                    hoursPerMonth = hoursPerMonth + _hoursFromFile;
                }

            }

            employeesSalary.Close();
            double _salary = double.Parse(_salaryValue);
            double salaryPerMonth = hoursPerMonth * _salary;
            salaryTextBox.Text = salaryPerMonth.ToString();
        }

        public void ReplaceHours(DateTimePicker dt, string _name, string replace)
        {
            string path = Application.StartupPath + "//Employees//" + _name + ".txt";
            StreamReader empHours = new StreamReader(path);
            string line;
            string date = "";
            int lineCount = 0;
            while ((line = empHours.ReadLine()) != null && date != dt.Value.ToString("dd MM yyyy "))
            {
                lineCount++;
                date = line.Substring(0, 11);
                if (date == dt.Value.ToString("dd MM yyyy "))
                {
                    empHours.Close();
                    string[] arrLine = File.ReadAllLines(path);
                    arrLine[lineCount - 1] = replace;
                    File.WriteAllLines(path, arrLine);
                    break;
                }
            }
            MessageBox.Show("Hours for" + Regex.Replace(_name, @"[\d-]", string.Empty) + " are updated!");
        }

        public void updateEmployee( ComboBox comboBox, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6)
        {
            string idna = Regex.Replace(comboBox.Text, "[^0-9.]", "");
            string _name = Regex.Replace(comboBox.Text, @"[\d-]", string.Empty);
            _name = Regex.Replace(_name, @"\s+", "");
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "update Employees set name = '" + t2.Text + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update Employees set surname = '" + t3.Text + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update Employees set city = '" + t4.Text + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update Employees set country = '" + t5.Text + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "update Employees set salary = '" + t6.Text + "'where ID='" + idna + "'";
            cmd.ExecuteNonQuery();
            MessageBox.Show("Employee " + _name + " is updated!");
            renameFile(comboBox, t1, t2);
            con.Close();
            clrAll(comboBox, t1, t2, t3, t4, t5, t6);
        }

        private void renameFile(ComboBox comboBox, TextBox t1, TextBox t2)
        {
            string path = Application.StartupPath + "\\Employees\\" + comboBox.Text + ".txt";
            string newName = Application.StartupPath + "\\Employees\\" + t1.Text + " " + t2.Text + ".txt";
            File.Move(path, newName);
        }
        
        private void clrAll(ComboBox comboBox, TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5, TextBox t6)
        {
            comboBox.Text = "Employees...";
            t1.Text = t2.Text = t3.Text = t4.Text = t5.Text = t6.Text = "";
        }

    }
}