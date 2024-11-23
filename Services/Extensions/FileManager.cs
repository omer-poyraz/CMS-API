using Microsoft.AspNetCore.Http;

namespace Services.Extensions
{
    public class FileManager
    {
        public async static Task<Dictionary<string, object>> FileUpload(IFormFile file, int id, string folder)
        {
            var result = new Dictionary<string, object>();

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{id}-{file.FileName}";
            var path = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var fileUrl = $"/{folder}/{fileName}";

            result.Add("FilesName", fileName);
            result.Add("FilesPath", folderPath);
            result.Add("FilesFullPath", fileUrl); 

            return result;
        }

        public static void FileDelete(string path, string file)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}
