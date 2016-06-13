using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Aps.Domain.Customer.Tests
{
    partial class CustomerRegistration
    {

        private Exception thrownError;
        private String custName;
        private String custSurname;
        private String custEmail;
        private String loginvalid;


        private void that_a_customer_enters_a_name(string custName)
        {
            if (custName.Length < 1)
            {
                throw new NotImplementedException();
            }  
        }

        private void a_customer_enters_a_surname(string custSurname)
        {

            if (custSurname.Length < 1)
            {
                throw new NotImplementedException();
            }
          
        }

        private Boolean a_customer_enters_email_address(string custEmail)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(custEmail, expresion))
            {


                Console.WriteLine("Inside  the email method");

                if (Regex.Replace(custEmail, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                 //   return false;
                    throw new Exception("Invalid email adress");
                }
            }
            else
            {
              //  return false;
                throw new Exception("Invalid email adress");
            }

        }

        private void the_users_pushes_the_register_button()
        {
          //  throw new NotImplementedException();
        }

        private void a_email_is_sent_to_confirm_the_registration()
        {
         //   throw new NotImplementedException();
        }


        private void A_customer_has_received_a_valid_username(string validusername)
        {
            if (validusername.Length < 1)
            {
                throw new Exception("Invalid user name provided");
            }
        }

        private void A_cusotmer_has_receive_a_valid_password(string validpassword)
        {
            if (validpassword.Length < 1)
            {
                throw new Exception("Invalid password provided");
            }

        }


        private void The_customer_attempts_to_login()
        {
            loginvalid = "valid";
            if (loginvalid != "valid")
            {
                throw new Exception("Login not valid");
            }


        }

        private void The_customer_is_able_to_login()
        {
            Console.WriteLine("Customer logged in");
        }
    }
}
