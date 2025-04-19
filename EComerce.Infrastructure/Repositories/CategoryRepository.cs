using EComerce.Core.Entities.Product;
using EComerce.Core.Interfaces;
using EComerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Repositories
{
    public class CategoryRepository:GenericRepository<Category>,ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext):base(dbContext) 
        {
           _dbContext = dbContext;
        }
    }
}
