namespace ECommerce.Application.Interfaces
{
    public interface IAwsService
    {
        Task<string> UploadFileAsync(IFormFile file, string folderName, string v);
        Task<bool> DeleteFileAsync(string fileKey);
    }
}
