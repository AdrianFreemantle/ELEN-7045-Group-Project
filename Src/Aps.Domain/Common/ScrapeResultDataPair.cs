namespace Aps.Domain.Common
{
    public struct ScrapeResultDataPair 
    {
        public string Id { get; private set; }
        public string FieldName { get; private set; }
        public string FieldValue { get; private set; }

        public ScrapeResultDataPair(string id, string fieldName, string fieldValue) : this()
        {
            Guard.ThatParameterNotNullOrEmpty(id, "id");
            Guard.ThatParameterNotNullOrEmpty(fieldName, "fieldName");
            Guard.ThatParameterNotNull(fieldValue, "fieldValue");

            Id = id;
            FieldName = fieldName;
            FieldValue = fieldValue;
        }
    }
}