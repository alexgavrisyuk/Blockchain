using BlockChain.Core;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blockchain.Consumer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddKafka(this IServiceCollection serviceCollection)
        {
            var configuration = serviceCollection.BuildServiceProvider().GetService<IConfiguration>();
            var options = new ConsumerConfig
            {
                BootstrapServers = configuration.GetValue("Kafka:BootstrapServers", string.Empty),
                GroupId = configuration.GetValue("Kafka:ClientId", string.Empty)
            };
            
            var producer = new ConsumerBuilder<Null, string>(options).Build();

            serviceCollection.AddSingleton(o => producer);
        }
    }
}