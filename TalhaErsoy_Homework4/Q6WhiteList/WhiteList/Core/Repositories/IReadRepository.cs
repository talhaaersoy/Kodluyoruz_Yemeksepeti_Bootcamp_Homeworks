using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Repositories
{
    public interface IReadRepository<T> where T : IEntity
    {
        Task<T> GetById(int id);

        Task<IQueryable<T>> GetAll();
    }
}
