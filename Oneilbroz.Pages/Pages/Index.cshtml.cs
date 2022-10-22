using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oneilbroz.Models;
using Oneilbroz.Services;
using System.Diagnostics;

namespace Oneilbroz.Pages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ItemDatabase _database;

        public IEnumerable<Item> Items { get; private set; } = Enumerable.Empty<Item>();

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        public IndexModel(ILogger<IndexModel> logger, ItemDatabase itemData)
        {
            _logger = logger;
            _database = itemData;
        }

        public void OnGet()
        {
            Items = _database.GetItems();
        }

        public async Task OnPostEmailAsync()
        {
            Debugger.Break();
        }
    }
}