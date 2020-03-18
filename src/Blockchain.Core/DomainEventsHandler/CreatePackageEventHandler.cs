using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blockchain.Domain.Events;
using Confluent.Kafka;
using MediatR;

namespace Blockchain.Core.DomainEventsHandler
{
    public class CreatePackageEventHandler : INotificationHandler<CreatePackageEvent>
    {
        private readonly IProducer<Null, string> _producer;

        public CreatePackageEventHandler(IProducer<Null, string> producer)
        {
            _producer = producer;
        }

        public async Task Handle(CreatePackageEvent notification, CancellationToken cancellationToken)
        {
            await _producer.ProduceAsync("package", new Message<Null, string>()
            {
                Value = "asdsd"
            });
        }
    }
}