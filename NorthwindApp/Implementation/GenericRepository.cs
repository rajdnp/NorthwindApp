using Microsoft.EntityFrameworkCore;
using NorthwindApp.Data;
using NorthwindApp.Events;
using NorthwindApp.Interfaces;

namespace NorthwindApp.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly NorthwindContext context;

        public GenericRepository(NorthwindContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public async Task<T?> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}
