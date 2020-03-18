using System;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace BlockChain.Core
{
    public class PackageEventsHandler
    {
        private readonly IConsumer<Null, string> _consumer;
        
        public PackageEventsHandler(IConsumer<Null, string> consumer)
        {
            _consumer = consumer;
        }

        public async Task Consume()
        {
            _consumer.Subscribe("package");

            while (true)
            {
                var consumeResult = _consumer.Consume();

                Console.WriteLine(JsonSerializer.Serialize(consumeResult));
            }
        }
    }
}