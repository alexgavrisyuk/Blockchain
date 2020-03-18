using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace Blockchain.Consumer.Services
{
    public class ConsumerBackgroundService : BackgroundService
    {
        private readonly IConsumer<Null, string> _consumer;

        public ConsumerBackgroundService(IConsumer<Null, string> consumer)
        {
            _consumer = consumer;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                _consumer.Subscribe("package");
                var consumeResult = _consumer.Consume();

                Console.WriteLine(JsonSerializer.Serialize(consumeResult));
            }
        }
    }
}