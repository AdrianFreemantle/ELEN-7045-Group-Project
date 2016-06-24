namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public interface ICustomerRepository
    {
        Customer fetchByID(CustomerId custID);
        bool custExists(CustomerId custID);
        void Save(Customer customer);
    }
}