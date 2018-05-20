using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracking
{
    class ClassLogin
    {
        private string username { get; set; }
        private string password { get; set; }

        //funksion per t kontrollau userin ene passin
        //te butoni i loginit e kom perdor
        public bool isCorrect(string _username, string _password)
        {
            if (_username == username && _password == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
