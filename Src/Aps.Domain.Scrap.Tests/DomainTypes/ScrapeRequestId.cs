using System;
using Aps.Domain.Scrap;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public struct ScrapeRequestId : IEquatable<ScrapeRequestId>
    {
        public Guid GUI { get; private set; }


        public ScrapeRequestId(Guid GUI) : this()
        {
            Guard.ThatValueTypeNotDefaut(GUI, "GUID");
            this.GUI = GUI;
        }

        public bool Equals(ScrapeRequestId other)
        {
            return GUI.Equals(other.GUI);
        }
    }
}