using Aps.Domain.Scraping;

namespace Aps.Domain.Services.ScrapeSessionResultPipeline
{
    public class BrokenScriptModule : IPipelineModule<ScrapeSessionResult>
    {
        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.BrokenScript))
            {
                //fetch company and mark script as broken
            }
        }
    }
}