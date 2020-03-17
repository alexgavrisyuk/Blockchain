using Blockchain.Core.ResponseModels;
using MediatR;

namespace Blockchain.Core.Commands
{
    public class CreatePackageCommand : IRequest<PackageResponseModel>
    {
        public int MaxNumberOfSplits { get; set; }
        public int CurrentNumberOfSplits { get; set; }
        
        public double PromotionPersentage { get; set; }

        public int NumberOfTokes { get; set; }

        public double MaxCommissions { get; set; }

        public double MaxBonuses { get; set; }
    }
}