using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Credential
{
    public struct SurnameVO : IIdentificationField
    {

        private readonly string _surname;

        public SurnameVO(string surnamevo)
        {
            Guard.ThatParameterNotNullOrEmpty(surnamevo , "Surname");
            if (!Validator.SurnameVoIsValid(surnamevo))
            {
                throw new DomainException("Surname credential", "Surname Invalid");
            }

            this._surname = surnamevo;
        }

        public override string ToString()
        {
            return _surname;
        }
    }
}
