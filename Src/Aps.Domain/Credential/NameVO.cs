using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Credential
{
    public struct NameVO : IIdentificationField
    {

        private readonly string _name;

        public NameVO(string namevo)
        {
            Guard.ThatParameterNotNullOrEmpty(namevo, "First Name");

            if (!Validator.NameVoIsValid(namevo))
            {
                throw new DomainException("First name credential", "First Name Invalid");
            }

            this._name = namevo; 
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
