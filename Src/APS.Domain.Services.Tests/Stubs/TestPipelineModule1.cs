using APS.Domain.Services.Tests.DomainTypes;

namespace APS.Domain.Services.Tests.Stubs
{
    public class TestPipelineModule1 : IPipelineModule<TestContext>
    {
        public void Process(TestContext input)
        {
            input.ProcessedByModule1 = true;
        }
    }
}