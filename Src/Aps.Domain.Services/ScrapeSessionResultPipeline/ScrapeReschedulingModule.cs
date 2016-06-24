using Aps.Domain.Scraping;

namespace Aps.Domain.Services.ScrapeSessionResultPipeline
{
    public class ScrapeReschedulingModule : IPipelineModule<ScrapeSessionResult>
    {
        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.SiteDownForMaintenance))
            {
              
            }
        }
    }
}