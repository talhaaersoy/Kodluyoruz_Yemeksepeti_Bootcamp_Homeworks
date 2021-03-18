using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.CustomExceptions;
using Core.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class RepositoryCore<TEntity, TContext> : IReadRepository<TEntity>, IWriteRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()

    {
        public async Task<TEntity> GetById(int id)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().FindAsync();
            }
        }


        public async Task<IQueryable<TEntity>> GetAll()
        {
            using (TContext context = new TContext())
            {
                IEnumerable<TEntity> result = await context.Set<TEntity>().ToListAsync();
                return result.AsQueryable();
            }
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                await context.AddAsync(entity);
                await SaveChanges();
                return entity;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                await SaveChanges();
                return entity;
            }
        }

        public async Task<bool> Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                return (await SaveChanges()) > 0;
            }
        }

        public virtual List<TEntity> ExecSqlQuery<TEntity>(string query, Func<DbDataReader, TEntity> map)
        {
            using (TContext context = new TContext())
            { 
                var command = context.Database.GetDbConnection().CreateCommand();
                command.CommandText = query;
                command.CommandType = System.Data.CommandType.Text;

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();

                var entities = new List<TEntity>();
                 var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    entities.Add(map(reader));
                }

                return entities;
            }
        }

        public async virtual Task<int> SaveChanges()
        {
            using (TContext context = new TContext())
            {
                int saveChangeResult = 0;
                try
                {
                    // validation

                    saveChangeResult = await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    HandleDbException(ex);
                }

                return saveChangeResult;
            }
        }

        public virtual void HandleDbException(Exception ex)
        {
            using (TContext context = new TContext())
            {
                if (ex is DbUpdateConcurrencyException concurrencyException)
                {
                    // handle exception
                    throw new ConcurrencyException();
                }
                else if (ex is DbUpdateException updateEx)
                {
                    if (updateEx.InnerException != null && updateEx.InnerException.InnerException != null)
                    {
                        if (updateEx.InnerException is SqlException sqlException)
                        {
                            switch (sqlException.Number)
                            {
                                case 2627: 
                                case 547: 
                                case 2601:
                                    throw new ConcurrencyException();
                                default:
                                    throw new DatabaseAccessException(updateEx.Message, updateEx.InnerException);
                            }
                        }
                    }

                    throw new DatabaseAccessException(updateEx.Message, updateEx.InnerException);
                }
            }
        }
    }
}
