using Aps.Domain.Credential;

namespace Aps.Domain.Customers
{
    public class CustomerFactory
    {

        public Customer Create(CustomerId id, EmailAddress emailAddress, CustomerName custName)
        {
            Guard.ThatValueTypeNotDefaut(id, "id");
            Guard.ThatValueTypeNotDefaut(emailAddress, "emailAddress");
            Guard.ThatValueTypeNotDefaut(custName, "custName");

            return new Customer(id,emailAddress,custName);
        }
    }
}