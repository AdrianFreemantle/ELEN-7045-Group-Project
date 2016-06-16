using System.Collections.Generic;

namespace APS.Domain.Services.Tests.DomainTypes
{
    //[DebuggerStepThrough]
    public class Pipeline<T>
    {
        private readonly Queue<IPipelineModule<T>> chain;

        public Pipeline(Queue<IPipelineModule<T>> chain)
        {
            this.chain = chain;
        }

        public virtual void Invoke(T input)
        {
            while (chain.Count != 0)
            {
                InvokeNext(input);
            }
        }

        protected virtual void InvokeNext(T input)
        {
            var processor = chain.Dequeue();
            processor.Process(input);
        }
    }
}