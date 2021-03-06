using Aps.Domain.Credential;
using Aps.Domain.Customers;

namespace Aps.Domain.Customer.Tests.Stubs
{
    public class CustomerExistsRepositoryStub : ICustomerRepository
    {
        public Customers.Customer fetchByID(CustomerId custID)
        {
            return new Customers.Customer(custID, new EmailAddress("man@moon.com"),new CustomerName("bob","Marley"));
        }

        public bool custExists(CustomerId custID)
        {
            return true;
        }

        public void Save(Customers.Customer customer)
        {
           
        }
    }

   

}