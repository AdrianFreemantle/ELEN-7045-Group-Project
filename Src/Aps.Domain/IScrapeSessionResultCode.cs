namespace Aps.Domain
{
    public interface IScrapeSessionResultCode
    {
        bool ScriptIsBroken();
        bool SiteIsDownForMaintenance();
        bool CredentialsAreInvalid();
    }
}