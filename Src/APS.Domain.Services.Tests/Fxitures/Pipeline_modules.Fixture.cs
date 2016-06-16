using APS.Domain.Services.Tests.DomainTypes;
using APS.Domain.Services.Tests.Stubs;
using LightBDD;
using Shouldly;

// ReSharper disable once CheckNamespace
namespace APS.Domain.Services.Tests
{
    public partial class Pipeline_modules : FeatureFixture
    {
        private Pipeline<TestContext> pipeline;
        private TestContext testContext;

        private void the_data_context_has_been_processed_by_module_two()
        {
            testContext.ProcessedByModule2.ShouldBe(true);
        }

        private void the_data_context_has_been_processed_by_module_one()
        {
            testContext.ProcessedByModule1.ShouldBe(true);
        }

        private void the_pipeline_is_invoked()
        {
            pipeline.Invoke(testContext);
        }

        private void a_data_context()
        {
            testContext = new TestContext();
        }

        private void a_pipeline_with_two_modules()
        {
            PipelineFactory<TestContext> factory = new PipelineFactory<TestContext>();

            factory
                .Register(new TestPipelineModule1())
                .Register(new TestPipelineModule2());

            pipeline = factory.Build();
        }
    }
}
