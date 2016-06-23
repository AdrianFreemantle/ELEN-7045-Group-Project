using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct RetryInterval
    {
        private readonly int _retryIntervalInHours;

        public RetryInterval(int retryIntervalInHours)
        {
            if (retryIntervalInHours < 0 || retryIntervalInHours > 24)
                throw new ArgumentOutOfRangeException("Retry interval cannot less than zero hours or greater than 24 hours");
            _retryIntervalInHours = retryIntervalInHours;
        }

        public static implicit operator int(RetryInterval retryInterval)
        {
            return retryInterval._retryIntervalInHours;
        }

        public override string ToString()
        {
            return _retryIntervalInHours.ToString();
        }
    }
}
