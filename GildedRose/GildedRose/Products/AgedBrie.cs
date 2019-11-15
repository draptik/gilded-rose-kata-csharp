namespace GildedRose.Products
{
    public class AgedBrie : BaseItem, ICanIterate
    {
        public AgedBrie(Item item) : base(item)
        {
        }

        public void Iterate()
        {
            Item.IncrementQuality();   
            
            Item.DecreaseSellIn();

            if (Item.SellByDateHasPassed())
            {
                Item.IncrementQuality();
            }
        }
    }
}