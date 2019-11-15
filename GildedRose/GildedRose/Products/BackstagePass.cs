namespace GildedRose.Products
{
    public class BackstagePass : BaseItem, IItemBehaviour
    {
        public BackstagePass(Item item)
        {
            Item = item;
        }

        public void Iterate()
        {
            IncrementQuality(Item);
            
            if (AreLessThan10DaysLeft(Item))
            {
                IncrementQuality(Item);
            }

            if (AreLessThan5DaysLeft(Item))
            {
                IncrementQuality(Item);
            }

            DecreaseSellIn(Item);

            if (SellByDateHasPassed(Item))
            {
                Item.Quality = 0;
            }
        }
    }
}