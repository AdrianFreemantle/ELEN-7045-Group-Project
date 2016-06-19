namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public interface ICustomerRepository
    {
        Customer fetchByID(CustomerID custID);
        bool custExists(CustomerID custID);
        void Save(Customer customer);
    }
}