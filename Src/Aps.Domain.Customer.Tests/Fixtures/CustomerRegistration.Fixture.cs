using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using Aps.Domain.Customer.Tests.Stubs;
using Aps.Domain.Customers;
using Aps.Domain.Services.CustomerServices;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Customer.Tests
{
    public partial class Customer_Registration_Service
    {
        private CustomerExistsRepositoryStub existsRepositoryStub;
        private CustomerRegistrationService custregistrationService;
        private IIdentificationField identificationField;
        string name;
        string surname;
        string email;
        Exception expectedError = null;

        private void Given_the_CustomerExistsRepositoryStub()
        {
            existsRepositoryStub = new CustomerExistsRepositoryStub();
        }

        private void Then_error()
        {
            Assert.IsNotNull(expectedError);
        }

        private void When_registering_a_customer_with_an_exiting_username()
        {
            try
            {
                custregistrationService.RegisterNewCustomer(identificationField, name, surname, email);
            }
            catch (Exception ex)
            {
                expectedError = ex;
            }
        }

        private void And_a_customer_email_address()
        {
            email = "bill@bob.com";
        }

        private void And_a_customer_surname()
        {
            surname = "dob";
        }

        private void And_a_customer_name()
        {
            name = "Leslie";
        }

        private void And_an_identification_field()
        {
            identificationField = new Aps.Domain.Credential.TelephoneNumber("0113334444");
        }

        private void And_a_customer_registration_service()
        {
            custregistrationService = new CustomerRegistrationService(existsRepositoryStub);
        }
    }
}
