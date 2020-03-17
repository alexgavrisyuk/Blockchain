using Blockchain.Domain.AggregatesModel;
using Blockchain.Domain.SeedWork;

namespace Blockchain.Infrastructure.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly BlockchainContext _blockchainContext;
        
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _blockchainContext;
            }
        }

        public Package Add(Package package)
        {
            return  _blockchainContext.Packages.Add(package).Entity;
        }

        public PackageRepository(BlockchainContext blockchainContext)
        {
            _blockchainContext = blockchainContext;
        }
    }
}