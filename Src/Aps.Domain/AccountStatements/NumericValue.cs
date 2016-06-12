using System;
using Aps.Domain.Common;

namespace Aps.Domain.AccountStatements
{
    public struct NumericValue
    {
        private readonly decimal value;

        private NumericValue(decimal value)
        {
            this.value = value;
        }

        public static NumericValue FromNumber(decimal value)
        {
            return new NumericValue(value);
        }

        public static NumericValue FromNumber(int value)
        {
            return new NumericValue(value);
        }

        public static NumericValue FromNumber(double value)
        {
            return new NumericValue((decimal)value);
        }

        public static NumericValue Parse(string value)
        {
            Guard.ThatParameterNotNullOrEmpty(value, "value");

            if (String.IsNullOrWhiteSpace(value))
                return new NumericValue();

            bool isNegative = ValueIsNegative(value);
            var cleanedValue = CleanNumber(value);

            if(isNegative) 
                return new NumericValue(0 - Decimal.Parse(cleanedValue));

            return new NumericValue(Decimal.Parse(cleanedValue));
        }

        private static string CleanNumber(string fieldValue)
        {
            string[] split = fieldValue.Split('.');

            if (split.Length == 1)
                return split[0].GetAllDigits();
            
            if (split.Length == 2)
            {
                string integerPart = split[0].GetAllDigits();
                string fractionalPart = split[1].GetAllDigits();
                return String.Format("{0},{1}", integerPart, fractionalPart);
            }

            throw new ArgumentException("Value pair does not contain a numeric value");
        }

        private static bool ValueIsNegative(string fieldValue)
        {
            string trimmedValue = fieldValue.Trim();

            return trimmedValue.StartsWith("-") || (trimmedValue.StartsWith("(") && trimmedValue.EndsWith(")"));
        }

        public override string ToString()
        {
            return String.Format("{0:00}", value);
        }
    }
}