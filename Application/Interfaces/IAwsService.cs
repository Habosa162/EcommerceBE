namespace ECommerce.Application.Interfaces
{
    public interface IAwsService
    {
        Task<string> UploadFileAsync(IFormFile file, string bucketName, string folderName);
        Task<bool> DeleteFileAsync(string bucketName, string fileKey);
    }
}
