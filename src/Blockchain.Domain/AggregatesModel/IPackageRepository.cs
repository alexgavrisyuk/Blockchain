using Blockchain.Domain.SeedWork;

namespace Blockchain.Domain.AggregatesModel
{
    public interface IPackageRepository : IRepository
    {
        Package Add(Package package);
    }
}