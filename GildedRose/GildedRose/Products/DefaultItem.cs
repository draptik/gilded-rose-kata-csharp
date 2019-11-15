namespace GildedRose.Products
{
    public class DefaultItem : BaseItem, IItemBehaviour
    {
        public DefaultItem(Item item) : base(item)
        {
        }

        public void Iterate()
        {
            Item.DecrementQuality();
            
            Item.DecreaseSellIn();

            if (Item.SellByDateHasPassed())
            {
                Item.DecrementQuality();
            }
        }
    }
}