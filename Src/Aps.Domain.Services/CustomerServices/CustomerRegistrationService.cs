using System;
using Aps.Domain.Credential;
using Aps.Domain.Customers;

namespace Aps.Domain.Services.CustomerServices
{
    public class CustomerRegistrationService
    {
        private readonly ICustomerRepository custRepo;
        private readonly CustomerFactory customerFactory;

        public CustomerRegistrationService(ICustomerRepository custRepo)
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