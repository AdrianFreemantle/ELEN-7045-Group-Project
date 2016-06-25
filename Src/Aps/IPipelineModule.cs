namespace Aps
{
    public interface IPipelineModule<in T>
    {
        void Process(T scrapeSessionResult);
    }
}