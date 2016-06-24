using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using Aps.Domain.Customer.Tests.DomainTypes;
using Aps.Domain.Customer.Tests.Stubs;
using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aps.Domain.Customer.Tests
{
    [TestClass]
    [Label("Customer Registration")]
    [FeatureDescription(@"Customer attemps to register")]
    public partial class Customer_Registration_Service : FeatureFixture
    {
        [TestMethod]
        public void Registering_Duplicate_Username_not_allowed()
        {
            Runner.RunScenario(
                Given_the_CustomerExistsRepositoryStub,
                And_a_customer_registration_service,
                And_an_identification_field,
                And_a_customer_name,
                And_a_customer_surname,
                And_a_customer_email_address,
                When_registering_a_customer_with_an_exiting_username,
                Then_error);
        }

        [TestMethod]
        public void Registering_With_unique_Username_allowed()
        {
            // Arrange  -   Given
            CustomerDoesNotExistRepositoryStub repo = new CustomerDoesNotExistRepositoryStub();
            CustomerRegService custregistrationService = new CustomerRegService(repo);

            IIdentificationField identificationField = new Aps.Domain.Credential.TelephoneNumber("0113334444");
            string name = "Leslie";
            string surname = "dob";
            string email = "bill@bob.com";
            Exception expectedError = null;
            // Act      -   When

            custregistrationService.RegisterNewCustomer(identificationField, name, surname, email);



            // Asert    -   Then 


            bool result = repo.SavedCustomer.Id.Equals(new CustomerId(identificationField));
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Registering_a_customer()
        {
            IIdentificationField identificationEmail = new EmailAddress("bob@marley.com");

            Console.WriteLine("Here :" + identificationEmail.ToString());


        }
    }
}