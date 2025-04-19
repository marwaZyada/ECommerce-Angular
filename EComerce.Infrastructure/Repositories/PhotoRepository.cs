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
    public class PhotoRepository:GenericRepository<Photo>,IPhotoRepository
    {
        public PhotoRepository(AppDbContext dbContext):base(dbContext) 
        {
            
        }
    }
}
