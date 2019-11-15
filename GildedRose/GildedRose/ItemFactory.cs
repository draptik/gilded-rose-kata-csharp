namespace GildedRose
{
    public static class ItemFactory
    {
        public static IItemBehaviour ToConcreteItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    return new AgedBrie(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePass(item);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(item);
                default:
                    return new DefaultItem(item);
            }
        }
    }
}