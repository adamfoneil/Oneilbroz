using Microsoft.AspNetCore.Mvc.RazorPages;
using Oneilbroz.Models;
using Oneilbroz.Services;

namespace Oneilbroz.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ItemDatabase _database;

        public IEnumerable<Item> Items { get; private set; } = Enumerable.Empty<Item>();

        public IndexModel(ILogger<IndexModel> logger, ItemDatabase itemData)
        {
            _logger = logger;
            _database = itemData;
        }

        public void OnGet()
        {
            Items = _database.GetItems();
        }
    }
}