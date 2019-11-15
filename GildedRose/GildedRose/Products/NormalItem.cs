namespace GildedRose.Products
{
    public class NormalItem : BaseItem, IItemBehaviour
    {
        public NormalItem(Item item) : base(item)
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