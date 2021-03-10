using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BitBoard.Domain.Shared.Models;
using BitBoard.Domain.Shared.Base;

namespace BitBoard.Domain.Shared.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly string containerName;
        private readonly string fullPath;

        public BaseRepository()
        {
            containerName = typeof(T).Name.ToLowerInvariant();
            var userHome = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var containerPath = Path.Join(userHome, "bitboard-dev", "containers");
            fullPath = Path.Join(containerPath, containerName + ".json");
            Directory.CreateDirectory(containerPath);
            if (!(new System.IO.FileInfo(fullPath).Exists))
            {
                var emptyList = new List<T>();
                var json = JsonSerializer.Serialize<IEnumerable<T>>(emptyList);
                File.WriteAllText(fullPath, json);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await ReadContainer()).ToList();
        }

        public async Task<T> GetAsync(string id)
        {
            return (await ReadContainer()).Where(x => x.Id == id).FirstOrDefault();
        }

        public async Task<IEnumerable<T>> GetMultipleAsync(IEnumerable<string> ids)
        {
            return (await ReadContainer()).Where(x => ids.Contains(x.Id)).ToList();
        }

        public async Task RemoveAsync(T entity)
        {
            var records = (await ReadContainer()).ToList();
            records.Remove(entity);
            await WriteContainer(records);
        }

        public async Task<T> UpsertAsync(T entity)
        {
            var records = (await ReadContainer()).ToList();
            var existingIndex = records.FindIndex(x => x.Id == entity.Id);
            if (existingIndex != -1)
            {
                records[existingIndex] = entity;
            }
            else
            {
                records.Add(entity);
            }
            await WriteContainer(records);
            return entity;
        }

        public async Task Clear()
        {
            await WriteContainer(new List<T>());
        }

        private async Task<IEnumerable<T>> ReadContainer()
        {
            var json = await File.ReadAllTextAsync(fullPath);
            var records = JsonSerializer.Deserialize<List<T>>(json);
            if (records == null) throw new JsonException("Failed to deserialize");
            return records;
        }

        private async Task WriteContainer(IEnumerable<T> records)
        {
            var json = JsonSerializer.Serialize<IEnumerable<T>>(records);
            await File.WriteAllTextAsync(fullPath, json);
        }
    }
}