using EComerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Repositories.Service
{
    public class ImageManagementService : IimageManagementService
    {
        private readonly IFileProvider _provider;

        public ImageManagementService(IFileProvider provider)
        {
           _provider = provider;
        }
        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string src)
        {
            var saveImageSrc=new List<string>();
            var imageDirectory = Path.Combine("wwwroot", "Images",src);
            if (!Directory.Exists(imageDirectory))
            {
                Directory.CreateDirectory(imageDirectory);
            }
            foreach (var item in files)
            {
                if (item.Length > 0)
                {
                    //get image name
                    var imagename = item.FileName;
                    var imageSrc=$"/Images/{src}/{imagename}";
                    var root = Path.Combine(imageDirectory, imagename);
                    using (FileStream stream = new FileStream(root, FileMode.Create))
                    {
                        await item.CopyToAsync(stream);
                    }
                    saveImageSrc.Add(imageSrc);
                }
            }
            return saveImageSrc;
           
            
        }

        public void DeleteImageAsync(string src)
        {
            var fileinfo=_provider.GetFileInfo(src);
            var root = fileinfo.PhysicalPath;
            File.Delete(root);
        }
    }
}
