using System;
using Aps.Domain.Scrap;

namespace Aps.Domain.Scrap.Tests.DomainTypes
{
    public struct ScrapSessionID : IEquatable<ScrapSessionID>
    {
        public String GUI { get; private set; }


        public ScrapSessionID(String GUI)
        {
            this.GUI = GUI;
        }

        public bool Equals(ScrapSessionID other)
        {
            return GUI.Equals(other.GUI);

        }
    }
}