namespace Aps.Domain.Common
{
    public enum DataType
    {
        Unkown,
        Date,
        Time,
        Duration,
        Month,
        Percentage, //created converter
        Balance, //created converter
        Text, //created converter
        KilowattHour //created converter
    }
}