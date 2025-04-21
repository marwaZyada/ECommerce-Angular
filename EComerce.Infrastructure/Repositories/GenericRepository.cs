using EComerce.Core.Entities;
using EComerce.Core.Interfaces;
using EComerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericIRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
           _dbContext = dbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           var entity= await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
         => await _dbContext.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var item in Includes)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        => await _dbContext.Set<T>().FindAsync(id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] Includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            foreach (var item in Includes)
            {
              query= query.Include(item);
            }
            return await query.FirstOrDefaultAsync(x=>EF.Property<int>(x,"Id") ==id);
        }

        public async Task UpdateAsync(T entity)
        {
            //_dbContext.Entry(entity).State=EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
