namespace GildedRose.Products
{
    public class DefaultItem : BaseItem, IItemBehaviour
    {
        public DefaultItem(Item item)
        {
            Item = item;
        }

        public void Iterate()
        {
            DecrementQuality(Item);
            
            DecreaseSellIn(Item);

            if (SellByDateHasPassed(Item))
            {
                DecrementQuality(Item);
            }
        }
    }
}