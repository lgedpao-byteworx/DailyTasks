using DailyTasks.Domain.Interfaces;
using Raven.Client.Documents;

namespace DailyTasks.Infrastructure.RavenDB
{
    public class RavenDBRepository<T> : IRepository<T>
    {
        public RavenDBRepository()
        {
        }
        public async Task<T> Create(T entity)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }

            return entity;
        }

        public async Task DeleteById(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                session.Delete(id);
                await session.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAll()
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
               return await session.Query<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(string id)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                return await session.LoadAsync<T>(id);
            }
        }

        public async Task<T> Update(T entity)
        {
            using (var session = DocumentStoreHolder.Store.OpenAsyncSession())
            {
                await session.StoreAsync(entity);
                await session.SaveChangesAsync();
            }

            return entity;
        }
    }
}

