using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IFileService
{
    Task<string> UploadFile(IFormFile file);
    Dictionary<string, string> GetFilesUrls(List<string> objectKeys, double duration);
}
