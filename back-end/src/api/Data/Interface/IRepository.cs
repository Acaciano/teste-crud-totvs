using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cbyk.ATS.API.Data.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(Guid key, TEntity newEntity);
        Task Remove(Guid id);
    }
}
