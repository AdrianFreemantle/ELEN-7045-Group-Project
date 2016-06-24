using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Credential;

namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public class Customer
    {
        private readonly CustomerId id;
        private EmailAddress emailAddress;
        private CustomerName custName;

        public CustomerId Id
        {
            get { return id; }
        }

        private Customer()
        {
            
        }

        internal Customer(CustomerId id, EmailAddress emailAddress, CustomerName custName)
        {
            this.id = id;
            this.emailAddress = emailAddress;
            this.custName = custName;
        }

        

        public override string ToString()
        {
            return String.Format("Customer {0} with id {1}" , custName , id); 
        }

        public void updateEmailAddress(EmailAddress eml)
        {
            Guard.ThatValueTypeNotDefaut(eml ,"eml");
            emailAddress = eml;
        }

        public void updateCustomerName(CustomerName Cname)
        {
            Guard.ThatValueTypeNotDefaut(Cname , "Cname");
            custName = Cname;
        }

    }
}