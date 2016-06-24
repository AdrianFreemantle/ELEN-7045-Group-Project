namespace Aps.Domain.Customers
{
    public interface  ICustomerRepository
    {
        Customer fetchByID(CustomerId custID);
        bool custExists(CustomerId custID);
        void Save(Customer customer);
    }
}