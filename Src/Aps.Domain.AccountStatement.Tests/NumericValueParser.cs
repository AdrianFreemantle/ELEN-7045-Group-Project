using System;
using System.Linq;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatement.Tests
{
    public class NumericValueParser
    {
        public virtual decimal Parse(TextValuePair valuePair)
        {
            Guard.ThatParameterNotDefaut(valuePair, "valuePair");

            if (String.IsNullOrWhiteSpace(valuePair.FieldValue))
                return 0;

            bool isNegative = ValueIsNegative(valuePair.FieldValue);
            var cleanedValue = CleanNumber(valuePair.FieldValue);

            if(isNegative) 
                return 0 - Decimal.Parse(cleanedValue);

            return Decimal.Parse(cleanedValue);
        }

        private string CleanNumber(string fieldValue)
        {
            string[] split = fieldValue.Split('.');

            if (split.Length == 1)
                return GetAllDigits(split[0]);
            
            if (split.Length == 2)
            {
                string integerPart = GetAllDigits(split[0]);
                string fractionalPart = GetAllDigits(split[1]);
                return String.Format("{0},{1}", integerPart, fractionalPart);
            }

            throw new ArgumentException("Value pair does not contain a numeric value");
        }

        bool ValueIsNegative(string fieldValue)
        {
            string trimmedValue = fieldValue.Trim();

            return trimmedValue.StartsWith("-") || (trimmedValue.StartsWith("(") && trimmedValue.EndsWith(")"));
        }

        private string GetAllDigits(string value)
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