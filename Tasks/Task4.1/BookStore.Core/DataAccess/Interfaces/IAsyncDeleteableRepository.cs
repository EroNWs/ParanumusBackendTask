using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.DataAccess.Interfaces;

public interface IAsyncDeleteableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
    Task DeleteAsync(TEntity entity);
    Task DeleteRangeAsync(IEnumerable<TEntity> entities);
}
