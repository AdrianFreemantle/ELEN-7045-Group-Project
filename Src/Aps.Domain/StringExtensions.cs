using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aps.Domain
{
    public static class StringExtensions
    {
        public static string GetAllDigits(this string value)
        {
            try
            {
                char[] result = value.Where(Char.IsDigit).ToArray();
                return new String(result);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        public static string SplitCamelCase(this string input)
        {
            return Regex.Replace(input, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}