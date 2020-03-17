using System.Threading;
using System.Threading.Tasks;
using Blockchain.Core.Commands;
using Blockchain.Core.ResponseModels;
using Blockchain.Domain.AggregatesModel;
using Blockchain.Domain.Events;
using Mapster;
using MediatR;

namespace Blockchain.Core.CommandsHandler
{
    public class PackageCommandsHandler : IRequestHandler<CreatePackageCommand, PackageResponseModel>
    {
        private readonly IPackageRepository _packageRepository;

        public PackageCommandsHandler(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<PackageResponseModel> Handle(CreatePackageCommand request, CancellationToken cancellationToken)
        {
            var newPackage = request.Adapt<Package>();
            newPackage.AddDomainEvent(new CreatePackageEvent(request.MaxNumberOfSplits, request.CurrentNumberOfSplits,
                request.PromotionPersentage, request.NumberOfTokes, request.MaxCommissions, request.MaxBonuses));

            _packageRepository.Add(newPackage);
            
            await _packageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            return newPackage.Adapt<PackageResponseModel>();
        }
    }
}