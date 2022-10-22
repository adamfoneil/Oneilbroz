using Oneilbroz.Models;
using System.Text.Json;

namespace Oneilbroz.Services
{
    public class ItemDatabase
    {
        private readonly IWebHostEnvironment _environment;

        public ItemDatabase(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IEnumerable<Item> GetItems()
        {            
            var path = Path.Combine(_environment.ContentRootPath, "App_Data\\Items");
            var files = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                var data = File.ReadAllText(file);
                var item = JsonSerializer.Deserialize<Item>(data) ?? throw new Exception($"Couldn't read item info from {file}");
                if (string.IsNullOrEmpty(item.Id)) item.Id = GetItemIdFromPath(file);
                if (string.IsNullOrEmpty(item.Thumbnail)) item.Thumbnail = FindThumbnail(file);
                yield return item;
            }
        }

        public static string GetItemIdFromPath(string path)
        {
            var folders = path.Split('\\');            
            return string.Join("-", folders[^3..^1]);
        }

        private string FindThumbnail(string path)
        {
            ArgumentNullException.ThrowIfNull(path, nameof(path));

            var defaultThumbnail = Path.Combine(Path.GetDirectoryName(path), "thumb.png");
            if (File.Exists(defaultThumbnail))
            {
                var bytes = File.ReadAllBytes(defaultThumbnail);
                return "data:image/png;base64," + Convert.ToBase64String(bytes);
            }

            return string.Empty;
        }
    }
}
