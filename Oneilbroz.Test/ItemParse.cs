using Oneilbroz.Services;

namespace Oneilbroz.Test
{
    [TestClass]
    public class ItemParse
    {
        [TestMethod]
        public void ItemIdFromPath()
        {
            var file = "C:\\Users\\adamo\\source\\repos\\Oneilbroz\\Oneilbroz.Pages\\App_Data\\Items\\leeboy\\01\\item.json";
            var itemId = ItemDatabase.GetItemIdFromPath(file);
            Assert.IsTrue(itemId.Equals("leeboy-01"));
        }
    }
}