using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Credential;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Aps.Domain.Customer.Tests
{
    public partial  class CustomerRegistrationAPS
    {
        private void that_a_customer_enters_a_name(string name)
        {
            var nme = new NameVO(name);
        }

        private void a_customer_enters_a_surname(string surname)
        {
            var snme = new SurnameVO(surname);
        }

        private void a_customer_enters_email_address(string email)
        {
            var e_mail = new EmailAddress(email);
        }

        private void the_users_pushes_the_register_button()
        {
    //        throw new NotImplementedException();
        }

        private void a_email_is_sent_to_confirm_the_registration()
        {
     //       throw new NotImplementedException();
        }

        private void A_customer_has_received_a_valid_username(string username)
        {
             var user_name = new UserName(username);
        }

        private void A_cusotmer_has_receive_a_valid_password(string passw)
        {
    //         var pass = new Password(passw);
        }

        private void The_customer_attempts_to_login()
        {
          
        }

        private void The_customer_is_able_to_login()
        {

        }
    }


}
