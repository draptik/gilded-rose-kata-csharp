namespace GildedRose.Products
{
    public class AgedBrie : BaseItem, IItemBehaviour
    {
        public AgedBrie(Item item)
        {
            Item = item;
        }

        public void Iterate()
        {
            IncrementQuality(Item);   
            
            DecreaseSellIn(Item);

            if (SellByDateHasPassed(Item))
            {
                IncrementQuality(Item);
            }
        }
    }
}