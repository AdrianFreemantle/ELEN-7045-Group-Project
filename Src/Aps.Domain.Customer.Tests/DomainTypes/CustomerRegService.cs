using System;
using Aps.Domain.Credential;

namespace Aps.Domain.Customer.Tests.DomainTypes
{
    public class CustomerRegService
    {
        private readonly ICustomerRepository custRepo;
        private readonly CustomerFactory customerFactory;

        public CustomerRegService(ICustomerRepository custRepo)
        {
            this.custRepo = custRepo;
            customerFactory = new CustomerFactory();
        }

        public void RegisterNewCustomer(IIdentificationField identificationField, string name , string surname , string email)
        {
            CustomerId customerId = new CustomerId(identificationField);


            if (custRepo.custExists(customerId))
            {
                throw new Exception("Customer username already exists");
            }

            Customer customer = customerFactory.Create(customerId, new EmailAddress(email), new CustomerName(name, surname));

            custRepo.Save(customer);
        }
    }
}