using CoreBase.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoreOnion.Persistence.EntityFramework.Abstractions;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> Table { get; }
}
