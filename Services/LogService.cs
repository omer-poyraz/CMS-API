using Newtonsoft.Json;
using Services.Contracts;
using Services.Extensions;

namespace Services
{
    public class LogService : ILogService
    {
        private readonly string _basePath;
        private readonly FileReaderService _readerService;

        public LogService(FileReaderService readerService)
        {
            _readerService = readerService;
            _basePath = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles");
            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public async Task AppendTextToFileAsync(string fileName, string content)
        {
            var filePath = Path.Combine(_basePath, fileName);

            await File.AppendAllTextAsync(filePath, content + Environment.NewLine);
        }

        public async Task<object> GetAllServices(int id)
        {
            try
            {
                var service = new ServiceType(id).Service;
                var createFile = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles", $"{service}Created.txt");
                var updateFile = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles", $"{service}Updated.txt");
                var deleteFile = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles", $"{service}Deleted.txt");

                var create = await _readerService.ReadFileAsync(createFile);
                var newCreate = create.Split("\r\n");
                var createJson = new List<object>();
                foreach (var line in newCreate.SkipLast(1))
                {
                    createJson.Add(JsonConvert.DeserializeObject(line)!);
                }

                var update = await _readerService.ReadFileAsync(updateFile);
                var newUpdate = update.Split("\r\n");
                var updateJson = new List<object>();
                foreach (var line in newUpdate.SkipLast(1))
                {
                    updateJson.Add(JsonConvert.DeserializeObject(line)!);
                }

                var delete = await _readerService.ReadFileAsync(deleteFile);
                var newDelete = delete.Split("\r\n");
                var deleteJson = new List<object>();
                foreach (var line in newDelete.SkipLast(1))
                {
                    deleteJson.Add(JsonConvert.DeserializeObject(line)!);
                }

                return new
                {
                    Message = "Success",
                    StatusCode = 200,
                    Result = new
                    {
                        Created = createJson,
                        Updated = updateJson,
                        Deleted = deleteJson,
                    }
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        async Task ILogService.DeleteLogService(int id, int crud)
        {
            try
            {
                var service = new ServiceType(id).Service;
                var crudType = new ServiceType(crud).Service;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "LogFiles", $"{service}{crudType}.txt");
                File.WriteAllText(path, string.Empty);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
