using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Credential
{
    public struct CcvNumber : IIdentificationField
    {

        private readonly string _ccvnumber;

        public CcvNumber(string ccvnumber)
        {
            Guard.ThatParameterNotNullOrEmpty(ccvnumber , "Ccv Number");

            if (ccvnumber.Length != 3)
            {
                throw new DomainException("Ccv Number", "Invalid Ccv Number passed");
            }

            if (!ccvnumber.All(c => c >= '0' && c <= '9'))
            {
                throw new DomainException("Ccv Number", "Invalid Ccv Number passed");
            }

            this._ccvnumber = ccvnumber;

        }

        public override string ToString()
        {
            return _ccvnumber;
        }

    }
}
