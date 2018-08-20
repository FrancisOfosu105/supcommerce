using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SupCommerce.Services.Picture
{
    public interface IPictureService
    {
        Task<string> UploadAsync(IFormFile file);
        
        void Remove(string fileName);
    }
}