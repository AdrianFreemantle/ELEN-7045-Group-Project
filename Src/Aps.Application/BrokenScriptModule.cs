using Aps.Domain.Companies;
using Aps.Domain.Scraping;

namespace Aps.Application
{
    public class BrokenScriptModule : IPipelineModule<ScrapeSessionResult>
    {
        private readonly ICompanyScriptService companyScriptService;

        public BrokenScriptModule(ICompanyScriptService companyScriptService)
        {
            Guard.ThatParameterNotNull(companyScriptService, "companyScriptService");
            this.companyScriptService = companyScriptService;
        }

        public void Process(ScrapeSessionResult scrapeSessionResult)
        {
            if (scrapeSessionResult.ResultCode.Equals(ScrapeSessionResultCode.BrokenScript))
            {
                companyScriptService.SetScriptAsBroken(scrapeSessionResult.AccountId.CompanyName);
            }
        }
    }
}