using Blazorise;

using System.Threading.Tasks;

namespace Sureze.Blazor;

public interface IFileUploader
{
    Task<string> UploadAsync(IFileEntry file, string saveName);
    bool Delete(string fullFilePath);
}