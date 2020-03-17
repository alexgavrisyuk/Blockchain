using System.Linq;
using System.Threading.Tasks;
using Blockchain.Domain.SeedWork;
using MediatR;

namespace Blockchain.Infrastructure
{
    static class MediatrExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, BlockchainContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}