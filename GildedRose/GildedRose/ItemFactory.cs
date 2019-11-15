using GildedRose.Products;

namespace GildedRose
{
    public static class ItemFactory
    {
        public static IItemBehaviour ToConcreteItem(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => (IItemBehaviour) new AgedBrie(item),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item),
                "Sulfuras, Hand of Ragnaros" => new Sulfuras(item),
                "Conjured Mana Cake" => new Conjured(item),
                _ => new DefaultItem(item)
            };
        }
    }
}