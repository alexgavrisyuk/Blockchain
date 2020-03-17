using Blockchain.Domain.SeedWork;

namespace Blockchain.Domain.AggregatesModel
{
    public class Package : Entity
    {
        public int Id { get; set; }
        
        public int MaxNumberOfSplits { get; set; }
        public int CurrentNumberOfSplits { get; set; }
        
        public double PromotionPersentage { get; set; }

        public int NumberOfTokes { get; set; }

        public double MaxCommissionsPerWeek { get; set; }

        public double MaxBonusesPerWeek { get; set; }
    }
}