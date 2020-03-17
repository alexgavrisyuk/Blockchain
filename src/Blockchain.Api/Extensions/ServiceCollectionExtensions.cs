using System;
using Blockchain.Core.Commands;
using Blockchain.Domain.AggregatesModel;
using Blockchain.Infrastructure;
using Blockchain.Infrastructure.Repositories;
using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Blockchain.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo  {Title = "Contract Manager API", Version = "v1"});
            });
        }
        
        public static void AddMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Startup).Assembly);
            services.AddMediatR(typeof(CreatePackageCommand).Assembly);
        }
        
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPackageRepository, PackageRepository>();
        }
        
        public static void AddDb(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var connectionString = configuration.GetValue("ConnectionStrings:DefaultConnection", string.Empty);

            services.AddDbContext<BlockchainContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
                opt.EnableSensitiveDataLogging();
            });
        }
        
        public static void AddKafka(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            var options = new ProducerConfig
            {
                BootstrapServers = configuration.GetValue("Kafka:BootstrapServers", string.Empty),
                ClientId = configuration.GetValue("Kafka:ClientId", string.Empty)
            };
            
            var producer = new ProducerBuilder<Null, string>(options).Build();

            services.AddScoped(o => producer);
        }
    }
}