using Blazorise;

using Microsoft.AspNetCore.Hosting;

using System.IO;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace Sureze.Blazor;

public class FileUploader : IFileUploader
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileUploader(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public bool Delete(string fullFilePath)
    {
        if (File.Exists(fullFilePath))
        {
            File.Delete(fullFilePath);
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<string> UploadAsync(IFileEntry file, string saveName)
    {
        try
        {
            Check.NotNull(file, nameof(file));

            FileInfo fileInfo = new FileInfo(file.Name);
            string fileName = saveName + fileInfo.Extension;

            var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\images\\profiles";

            if (!Directory.Exists(folderDirectory))
            {
                Directory.CreateDirectory(folderDirectory);
            }

            string filePath = Path.Combine(folderDirectory, fileName);

            await using FileStream fs = new FileStream(filePath, FileMode.Create);

            await file.WriteToStreamAsync(fs);

            string fullPath = $"/images/profiles/{fileName}";

            return fullPath;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
