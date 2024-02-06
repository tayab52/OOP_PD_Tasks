using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2_PD
{
    internal class SignUp
    {
        public SignUp() { }
        public SignUp(string name, string password, string Role)
        {

            userName = name;
            userPassword = password;
            role = Role;

        }
        public string userName;
        public string userPassword;
        public string role;
    }
    class Products
    {
        public string productName;
        public int productQuantity;
        public float productPrice;
    }
}
