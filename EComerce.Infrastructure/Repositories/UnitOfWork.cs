using EComerce.Core.Interfaces;
using EComerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public ICategoryRepository CategoryRepository { get ; set; }
        public IProductRepository ProductRepository { get; set ; }
        public IPhotoRepository PhotoRepository { get ; set ; }
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository=new ProductRepository(_dbContext);
            PhotoRepository = new PhotoRepository(_dbContext);
           
        }
    }
}
