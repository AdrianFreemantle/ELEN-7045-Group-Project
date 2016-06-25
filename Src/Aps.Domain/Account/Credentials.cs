using System;

namespace Aps.Domain.Account
{
    public struct Credentials
    {
        private readonly IIdentificationField identificationfield;
        private readonly ISecurityField securityfield;

        public IIdentificationField Identificationfield
        {
            get { return identificationfield; }
        }

        public ISecurityField Securityfield
        {
            get { return securityfield; }
        }

        private Credentials(IIdentificationField identificationfield, ISecurityField securityfield)
        {
            this.identificationfield = identificationfield;
            this.securityfield = securityfield;
        }

        public static Credentials Create(IIdentificationField identificationfield, ISecurityField securityfield)
        {
            Guard.ThatValueTypeNotDefaut(identificationfield, "Identificationfield");
            Guard.ThatValueTypeNotDefaut(securityfield, "SecurityField");

            return new Credentials(identificationfield, securityfield);
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", identificationfield, securityfield);
        }
    }
}