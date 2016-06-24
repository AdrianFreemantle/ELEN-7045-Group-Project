using Aps.Domain.Services;

namespace APS.Domain.Services.Tests.Stubs
{
    public class TestPipelineModule2 : IPipelineModule<TestContext>
    {
        public void Process(TestContext input)
        {
            input.ProcessedByModule2 = true;
        }
    }
}