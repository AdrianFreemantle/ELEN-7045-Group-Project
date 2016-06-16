namespace APS.Domain.Services.Tests.DomainTypes
{
    public interface IPipelineModule<in T>
    {
        void Process(T input);
    }
}