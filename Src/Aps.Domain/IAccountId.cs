﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain
{
    public interface IAccountId
    {
        IAccountNumber AccountNumber { get; }   
        ICompanyName CompanyName { get; }   
    }
}
