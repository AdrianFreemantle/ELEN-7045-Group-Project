using LightBDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace APS.Domain.Services.Tests
{
    [TestClass]
    [ScenarioCategory("Process Scrape Result")]
    [FeatureDescription(@"A pipeline can be used to create composable behavior between services.")]
    public partial class Pipeline_modules
    {
        [TestMethod]
        public void Invoking_a_pipeline_passes_the_data_context_to_all_modules()
        {
            Runner.RunScenario(
                given => a_pipeline_with_two_modules(),
                and => a_data_context(),
                when => the_pipeline_is_invoked(),
                then => the_data_context_has_been_processed_by_module_one(),
                and => the_data_context_has_been_processed_by_module_two());
        }
    }
}
