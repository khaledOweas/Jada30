using Jada30Core.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jada30Core.Application.Services
{
    public class FileStorageService: IFileStorageService
    {
        private readonly string _uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (!Directory.Exists(_uploadsFolder))
                Directory.CreateDirectory(_uploadsFolder);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }

        public void DeleteFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
    }
}
