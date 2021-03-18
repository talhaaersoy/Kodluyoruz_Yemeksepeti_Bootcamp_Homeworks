using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IWriteRepository<T> where T : IEntity

    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<bool> Delete(T entity);

    }
}
