using PeblitAPI.Domain.Entities;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<PeblitItem> PeblitItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
