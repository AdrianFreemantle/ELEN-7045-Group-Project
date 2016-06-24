namespace Aps.Domain.Services
{
    public interface IPipelineModule<in T>
    {
        void Process(T scrapeSessionResult);
    }
}