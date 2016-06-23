namespace Aps.Domain
{
    public interface ICredentials
    {
        ISecurityField securityField { get; set; }
        IIdentificationField identificationField { get; set; }
    }
}
