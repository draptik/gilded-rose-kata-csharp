using GildedRose.Products;

namespace GildedRose
{
    public static class ItemFactory
    {
        public static ICanIterate ToConcreteItem(Item item)
        {
            return item.Name switch
            {
                var s when s.StartsWith("Aged Brie") => (ICanIterate) new AgedBrie(item),
                var s when s.StartsWith("Backstage") => new BackstagePass(item),
                var s when s.StartsWith("Sulfuras") => new Sulfuras(item),
                var s when s.StartsWith("Conjured") => new Conjured(item),
                _ => new NormalItem(item)
            };
        }
    }
}