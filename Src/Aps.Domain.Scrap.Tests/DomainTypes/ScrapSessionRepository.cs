using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public struct ScrapSessionRepository
    {

       private readonly String ScrapErrorCode;
       private readonly String BaseUrl;
       private readonly AccountId accountId;
       private readonly Schedule schedule;
       private readonly ScrapResultDataPair scrapResultDataPair;
       private readonly ScrapSessionStatus scrapSessionStatus;
       private readonly List<Credential> credentials;



        private ScrapShedule(DateTime dateTime, String baseUrl)
        {
            Console.Write("Shedule A Scrap");
        }


        private ScrapAuditLog(ScrapRequest scrapRequest)
        {
            Console.Write("Write to Repo");
        }


        private ScrapResultFormattor(ScrapResult scrapResult)
        {
            Console.Write("Parse the Data from a Scrap Result");

            ReturnMessage ScrapResultDataPair[];
        }




        
    }
}