using EComerce.Core.Interfaces;
using EComerce.Core.Services;
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
        private readonly IimageManagementService _service;

        public ICategoryRepository CategoryRepository { get ; set; }
        public IProductRepository ProductRepository { get; set ; }
        public IPhotoRepository PhotoRepository { get ; set ; }
        public UnitOfWork(AppDbContext dbContext,IimageManagementService service)
        {
            _dbContext = dbContext;
            _service = service;
            CategoryRepository = new CategoryRepository(_dbContext);
            ProductRepository=new ProductRepository(_dbContext,_service);
            PhotoRepository = new PhotoRepository(_dbContext);
           
        }
    }
}
