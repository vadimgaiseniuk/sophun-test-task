using System.Threading.Tasks;

namespace Services.FileHandlingService
{
    public interface IFileHandlingService
    {
        Task<string> ReadFileAsync(string filePath);

        Task<string> ReadFileFromResourcesAsync(string fileName);
    }
}