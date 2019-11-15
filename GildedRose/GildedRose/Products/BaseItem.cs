namespace GildedRose.Products
{
    public abstract class BaseItem
    {
        protected Item Item { get; set; }
        
        private protected static bool SellByDateHasPassed(Item item) => item.SellIn < 0;

        private protected static bool AreLessThan5DaysLeft(Item item) => item.SellIn < 6;

        private protected static bool AreLessThan10DaysLeft(Item item) => item.SellIn < 11;

        private static bool QualityIsBelowMaximum(Item item) => item.Quality < 50;

        private static bool QualityIsAboveMinimum(Item item) => item.Quality > 0;

        private protected static void DecreaseSellIn(Item item) => item.SellIn -= 1;

        private protected static void IncrementQuality(Item item)
        {
            if (QualityIsBelowMaximum(item))
            {
                item.Quality += 1;    
            }
        }

        private protected static void DecrementQuality(Item item)
        {
            if (QualityIsAboveMinimum(item))
            {
                item.Quality -= 1;    
            }
        }

        public override string ToString() => Item.ToString();
    }
}