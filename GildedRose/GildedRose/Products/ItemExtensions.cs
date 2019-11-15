namespace GildedRose.Products
{
    public static class ItemExtensions
    {
        public static bool SellByDateHasPassed(this Item item) => item.SellIn < 0;

        public static bool AreLessThan5DaysLeft(this Item item) => item.SellIn < 6;

        public static bool AreLessThan10DaysLeft(this Item item) => item.SellIn < 11;

        private static bool QualityIsBelowMaximum(this Item item) => item.Quality < 50;

        private static bool QualityIsAboveMinimum(this Item item) => item.Quality > 0;

        public static void DecreaseSellIn(this Item item) => item.SellIn -= 1;

        public static void IncrementQuality(this Item item)
        {
            if (QualityIsBelowMaximum(item))
            {
                item.Quality += 1;    
            }
        }

        public static void DecrementQuality(this Item item)
        {
            if (QualityIsAboveMinimum(item))
            {
                item.Quality -= 1;    
            }
        }
    }
}