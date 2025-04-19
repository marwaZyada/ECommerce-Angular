using EComerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Core.Interfaces
{
    public interface IGenericIRepository< T> where T : class
    {
       Task< IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func< T,object>>[] Includes);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] Includes);
        Task AddAsync(T entity);
       Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    
    }
}
