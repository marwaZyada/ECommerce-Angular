using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EComerce.Core.Services
{
    public interface IimageManagementService
    {
        Task<List<string>> AddImageAsync(IFormFileCollection files, string src);
       void DeleteImageAsync(string src);
        
    }
}
