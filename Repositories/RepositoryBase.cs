using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using desafio.Models.Abstract;
using desafio.Interfaces.Repositories;

namespace desafio.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private string path;
        public RepositoryBase(string filename, string defaultFolder = "Data")
        {
            var directory = Directory.GetCurrentDirectory();
            path = Path.Combine(directory, defaultFolder, $"{filename}.json");
        }

        public List<T> FindAll()
        {
            if (!File.Exists(path))
            {
                return new List<T>();
            }

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<T>>(json);
        }

        public void Save(List<T> entities)
        {
            var json = JsonSerializer.Serialize(entities, new JsonSerializerOptions() { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}