using MediatR;

namespace Blockchain.Domain.Events
{
    public class CreatePackageEvent : INotification
    {
        public int MaxNumberOfSplits { get; set; }
        public int CurrentNumberOfSplits { get; set; }
        
        public double PromotionPersentage { get; set; }

        public int NumberOfTokes { get; set; }

        public double MaxCommissionsPerWeek { get; set; }

        public double MaxBonusesPerWeek { get; set; }

        public CreatePackageEvent(int maxNumberOfSplits, int currentNumberOfSplits, double promotionPersentage,
            int numberOfTokes, double maxCommissionsPerWeek, double maxBonusesPerWeek)
        {
            MaxNumberOfSplits = maxNumberOfSplits;
            CurrentNumberOfSplits = currentNumberOfSplits;
            PromotionPersentage = promotionPersentage;
            NumberOfTokes = numberOfTokes;
            MaxCommissionsPerWeek = maxCommissionsPerWeek;
            MaxBonusesPerWeek = maxBonusesPerWeek;
        }
    }
}