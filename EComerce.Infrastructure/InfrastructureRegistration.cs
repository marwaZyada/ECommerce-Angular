using EComerce.Core.Interfaces;
using EComerce.Core.Services;
using EComerce.Infrastructure.Data;
using EComerce.Infrastructure.Repositories;
using EComerce.Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfigration(this IServiceCollection Services,IConfiguration configuration)
        {
            Services.AddScoped(typeof(IGenericIRepository<>),typeof(GenericRepository<>));
            //Services.AddScoped<ICategoryRepository, CategoryRepository>();
            //Services.AddScoped<IProductRepository, ProductRepository>();
            //Services.AddScoped<IPhotoRepository, PhotoRepository>();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            Services.AddSingleton<IimageManagementService,ImageManagementService>();

            //apply dbcontext
            Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("EcomDatabase"));
            });

            return Services;
        }
    }
}
