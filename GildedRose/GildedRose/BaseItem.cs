namespace GildedRose
{
    public abstract class BaseItem
    {
        protected Item Item;
        
        private protected static bool IsBackstagePass(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";

        private protected static bool IsNotSulfuras(Item item) => item.Name != "Sulfuras, Hand of Ragnaros";

        private protected static bool IsNotBackstagePass(Item item) => !IsBackstagePass(item);

        private protected static bool IsAgedBrie(Item item) => item.Name == "Aged Brie";
        
        private protected static bool IsNotAgedBrie(Item item) => !IsAgedBrie(item);

        private protected static bool SellByDateHasPassed(Item item) => item.SellIn < 0;

        private protected static bool AreLessThan5DaysLeft(Item item) => item.SellIn < 6;

        private protected static bool AreLessThan10DaysLeft(Item item) => item.SellIn < 11;

        private protected static bool QualityIsBelowMaximum(Item item) => item.Quality < 50;

        private protected static bool QualityIsAboveMinimum(Item item) => item.Quality > 0;

        private protected static int DecreaseSellIn(Item item) => item.SellIn -= 1;

        private protected static int IncrementQuality(Item item)
        {
            if (QualityIsBelowMaximum(item))
            {
                return item.Quality += 1;    
            }

            return item.Quality;
        }

        private protected static int DecrementQuality(Item item)
        {
            if (IsNotSulfuras(item) && QualityIsAboveMinimum(item))
            {
                return item.Quality -= 1;    
            }

            return item.Quality;
        }

        public override string ToString() => Item.ToString();
    }
}