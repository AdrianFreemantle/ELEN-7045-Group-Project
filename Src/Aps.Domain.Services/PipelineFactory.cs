using System.Collections.Generic;
using Aps.Domain.Scraping;
using Aps.Domain.Services.AccountStatementServices;
using Aps.Domain.Services.ScrapeSessionResultPipeline;

namespace Aps.Domain.Services
{
    public class PipelineFactory<T>
    {
        protected readonly List<IPipelineModule<T>> ModuleChain = new List<IPipelineModule<T>>();

        public virtual PipelineFactory<T> Register(IPipelineModule<T> m)
        {
            ModuleChain.Add(m);
            return this;
        }

        public virtual Pipeline<T> Build()
        {
            var chain = new Queue<IPipelineModule<T>>();

            foreach (var type in ModuleChain)
            {
                chain.Enqueue(type);
            }

            return new Pipeline<T>(chain);
        }
    }
}