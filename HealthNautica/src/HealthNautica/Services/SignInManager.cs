using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthNautica.Services
{
    public class SignInManager
    {
        private string _username;
        private string _password;
        public SignInManager(string username, string password)
        {
            _username = username;
            _password = password;
        }
        public bool ValidateUser()
        {


            //Logic follows for DB Check

            return _username == "test" && _password == "test";

        }

    }
}
