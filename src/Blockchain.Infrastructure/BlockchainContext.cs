using System;
using System.Threading;
using System.Threading.Tasks;
using Blockchain.Domain.AggregatesModel;
using Blockchain.Domain.SeedWork;
using Blockchain.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Blockchain.Infrastructure
{
    public class BlockchainContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;
        private IDbContextTransaction _currentTransaction;
        
        public DbSet<Package> Packages { get; set; }
        
        
        public BlockchainContext(DbContextOptions<BlockchainContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PackageEntityConfiguration());
        }
        
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _mediator.DispatchDomainEventsAsync(this);
    
            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}