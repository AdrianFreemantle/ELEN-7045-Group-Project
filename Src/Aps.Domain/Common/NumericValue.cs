using System;

namespace Aps.Domain.Common
{
    public struct NumericValue : IFormattable
    {
        private const string DefaultNumberFormat = "{0:00}";
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

        public int ToInt32()
        {
            return Convert.ToInt32(value);
        }

        public uint ToUInt32()
        {
            return Convert.ToUInt32(value);
        }

        public decimal ToDecimal()
        {
            return value;
        }

        public double ToDouble()
        {
            return Convert.ToDouble(value);
        }

        public override string ToString()
        {
            return ToString(GetDefaultFormatProvider());
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(DefaultNumberFormat, provider);
        }

        public string ToString(string format)
        {
            return ToString(DefaultNumberFormat, GetDefaultFormatProvider());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            IFormatProvider provider = formatProvider ?? GetDefaultFormatProvider();
            format = format ?? DefaultNumberFormat;

            return String.Format(provider, format, value);
        }

        private static IFormatProvider GetDefaultFormatProvider()
        {
            DefaultFormatProviderSettings formatProviderSettings = new DefaultFormatProviderSettings();
            return formatProviderSettings.NumberFormat;
        }
    }
}