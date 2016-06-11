using System;
using System.Linq;

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
    }
}