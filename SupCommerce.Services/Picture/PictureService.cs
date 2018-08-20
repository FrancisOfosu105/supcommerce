using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace SupCommerce.Services.Picture
{
    public class PictureService : IPictureService
    {
        private readonly IHostingEnvironment _hosting;

        public PictureService(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }

        public async Task<string> UploadAsync(IFormFile file)
        {
            var uploadFolderPath = Path.Combine(_hosting.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public void Remove(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            var path = Path.Combine(_hosting.WebRootPath, "uploads", fileName);

            var fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
        }
    }
}