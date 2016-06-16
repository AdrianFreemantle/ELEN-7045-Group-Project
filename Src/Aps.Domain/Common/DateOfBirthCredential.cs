using System;

namespace Aps.Domain.Common
{
    internal struct DateOfBirthCredential : ICredential
    {
        private DateTime dateofbirthCredential;

        private DateOfBirthCredential(DateTime dateofbirthCredential)
        {
            this.dateofbirthCredential = dateofbirthCredential;
        }

        public bool IsValid()
        {
            if (dateofbirthCredential > DateTime.Now)
                return false;

            return true;
        }
    }
}