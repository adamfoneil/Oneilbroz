namespace Oneilbroz.Models
{
    public class Item
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Thumbnail { get; set; } = "thumb.png";
        public decimal Price { get; set; }
    }
}
