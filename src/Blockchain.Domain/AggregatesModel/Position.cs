using System.Collections.Generic;
using Blockchain.Domain.SeedWork;

namespace Blockchain.Domain.AggregatesModel
{
    public class Position : Entity
    {
        public int MaxNumberOfSplits { get; set; }

        public List<Package> Packages { get; set; }
    }
}