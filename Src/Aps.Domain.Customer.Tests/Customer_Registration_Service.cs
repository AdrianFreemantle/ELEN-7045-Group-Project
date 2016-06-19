using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            // Arrange  -   Given
            ICustomerRepository repo = new CustomerExistsRepositoryStub();
            CustomerRegService custregistrationService = new CustomerRegService(repo);
            IIdentificationField identificationField = new TelePhoneNumber("0113334444");
            string name = "Leslie";
            string surname = "dob";
            string email = "bill@bob.com";
            Exception expectedError = null;
            // Act      -   When
            try
            {
                custregistrationService.RegisterNewCustomer(identificationField, name, surname, email);
            }
            catch (Exception ex)
            {
                expectedError = ex;
            }

            // Asert    -   Then 

            Assert.IsNotNull(expectedError);

        }

        [TestMethod]
        public void Registering_With_unique_Username_allowed()
        {
            // Arrange  -   Given
            CustomerDoesNotExistRepositoryStub repo = new  CustomerDoesNotExistRepositoryStub();
            CustomerRegService custregistrationService = new CustomerRegService(repo);
            IIdentificationField identificationField = new TelePhoneNumber("0113334444");
            string name = "Leslie";
            string surname = "dob";
            string email = "bill@bob.com";
            Exception expectedError = null;
            // Act      -   When
 
                custregistrationService.RegisterNewCustomer(identificationField, name, surname, email);

               

            // Asert    -   Then 


            bool result = repo.SavedCustomer.Id.Equals(new CustomerID(identificationField));
            Assert.IsTrue(result);
        }


    }
}