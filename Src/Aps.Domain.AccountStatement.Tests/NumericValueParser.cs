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

            string[] split = valuePair.FieldValue.Split('.');

            if(split.Length > 2)
                throw new ArgumentException();

            string integerPart = GetAllDigits(split[0]);
            string fractionalPart = GetAllDigits(split[1]);

            string fullNumber = String.Format("{0},{1}", integerPart, fractionalPart);

            return Decimal.Parse(fullNumber);
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