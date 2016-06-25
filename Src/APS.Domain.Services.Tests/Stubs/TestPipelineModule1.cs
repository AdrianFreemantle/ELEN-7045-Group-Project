using Aps;
using Aps.Domain.Services;

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