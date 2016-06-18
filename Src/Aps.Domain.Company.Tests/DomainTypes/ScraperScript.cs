using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aps.Domain.Company.Tests.DomainTypes
{
    public struct ScraperScript : IEquatable<ScraperScript>
    {
        private string _script;

        public ScraperScript(string script)
        {
            if (string.IsNullOrEmpty(script))
                throw new ArgumentException("Cannot create scraper script with empty script");
            _script = script;
        }

        public bool Equals(ScraperScript other)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return _script;
        }
    }
}
