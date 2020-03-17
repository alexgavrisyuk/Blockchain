using System.Threading;
using System.Threading.Tasks;
using Blockchain.Domain.Events;
using MediatR;

namespace Blockchain.Core.DomainEventsHandler
{
    public class CreatePackageEventHandler : INotificationHandler<CreatePackageEvent>
    {
        public async Task Handle(CreatePackageEvent notification, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var a = 2;
        }
    }
}