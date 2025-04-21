using EComerce.Core.Entities.Product;
using EComerce.Core.Interfaces;
using EComerce.Core.Services;
using EComerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IimageManagementService _service;

        public ProductRepository(AppDbContext dbContext,IimageManagementService service) : base(dbContext)
        {
            _dbContext = dbContext;
           _service = service;
        }

        async Task<bool> IProductRepository.DeleteAsync(int id)
        {
            var product = await _dbContext.Products.Include(p => p.Category).Include(p => p.photos)
                .FirstOrDefaultAsync(p => p.Id == id);
            var imagesname = product.photos.Select(p=>p.ImageName).ToList();
            if (product == null) return false;
             
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            foreach (var item in imagesname)
            {
                _service.DeleteImageAsync(item);
            }
          

            return true;


        }
    }
}
