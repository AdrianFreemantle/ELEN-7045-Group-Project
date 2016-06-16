using System;
using Aps.Domain;
using Aps.Domain.Common;
using Aps.Domain.Credential;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo
{
    public struct CreditCardNumber : IIdentificationField, ISecurityField
    {
        public string GetDetails(IDecryptionService decryptionService)
        {
            throw new NotImplementedException();
        }
    }

    public struct UnsafeCredentials
    {
        public string Identification { get; private set; }
        public string Authentication { get; private set; }

        internal UnsafeCredentials(string identification, string authentication)
            : this()
        {
            Identification = identification;
            Authentication = authentication;
        }
    }

    public struct SecureCredentials
    {
        private readonly ISecurityField securityField;
        private readonly IIdentificationField identificationField;

        public SecureCredentials(ISecurityField securityField, IIdentificationField identificationField)
        {
            this.securityField = securityField;
            this.identificationField = identificationField;
        }

        public UnsafeCredentials GetUnsafeCredentials(IDecryptionService decryptionService)
        {
            ISecurityField secureIdentificationField = identificationField as ISecurityField;
            string identification;

            if (secureIdentificationField == null)
            {
                identification = identificationField.ToString();
            }
            else
            {
                identification = secureIdentificationField.GetDetails(decryptionService);
            }

            string authenticationField = securityField.GetDetails(decryptionService);

            return new UnsafeCredentials(identification, authenticationField);
        }

    }

  
}
