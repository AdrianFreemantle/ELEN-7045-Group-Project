using System;

namespace Aps.Domain.Common
{
    public struct TextValuePair : IEquatable<TextValuePair>
    {
        public string FieldName { get; private set; }
        public string FieldValue { get; private set; }

        public TextValuePair(string fieldName, string fieldValue) : this()
        {
            Guard.ThatParameterNotNullOrEmpty(fieldName, "fieldName");
            Guard.ThatParameterNotNull(fieldValue, "fieldValue");

            FieldName = fieldName;
            FieldValue = fieldValue;
        }

        public bool Equals(TextValuePair other)
        {
            return other.FieldName == FieldName 
                   && other.FieldValue == FieldValue;
        }
    }
}