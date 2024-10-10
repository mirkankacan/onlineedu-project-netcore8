using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Repositories
{
    /* Primary constructor .NET 8 ile birlikte geldi */

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly OnlineEduContext _context;

        public GenericRepository(OnlineEduContext context)
        {
            _context = context;
        }

        public DbSet<T> Table { get => _context.Set<T>(); }

        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await Table.FindAsync(id);
            Table.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).CountAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}