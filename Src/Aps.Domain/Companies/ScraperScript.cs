using System;

namespace Aps.Domain.Companies
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
            return _script.Equals(other._script);
        }

        public override string ToString()
        {
            return _script;
        }
    }
}
