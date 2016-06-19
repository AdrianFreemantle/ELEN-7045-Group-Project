using Aps.Domain.Credential;
using Aps.Domain.Customer.Tests.DomainTypes;

namespace Aps.Domain.Customer.Tests.Stubs
{
    public class CustomerExistsRepositoryStub : ICustomerRepository
    {
        public DomainTypes.Customer fetchByID(CustomerID custID)
        {
            return new DomainTypes.Customer(custID, new EmailAddress("man@moon.com"),new CustomerName("bob","Marley"));
        }

        public bool custExists(CustomerID custID)
        {
            return true;
        }

        public void Save(DomainTypes.Customer customer)
        {
           
        }
    }

   

}