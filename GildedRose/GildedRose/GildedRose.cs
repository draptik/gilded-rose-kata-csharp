using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsAgedBrie(item) || IsBackstagePass(item))
                {
                    if (QualityIsBelowMaximum(item))
                    {
                        IncrementQuality(item);

                        if (IsBackstagePass(item))
                        {
                            if (AreLessThan10DaysLeft(item))
                            {
                                if (QualityIsBelowMaximum(item))
                                {
                                    IncrementQuality(item);
                                }
                            }

                            if (AreLessThan5DaysLeft(item))
                            {
                                if (QualityIsBelowMaximum(item))
                                {
                                    IncrementQuality(item);
                                }
                            }
                        }
                    }
                }
                else
                {
                    DecrementQuality(item);
                }

                if (IsNotSulfuras(item))
                {
                    DecreaseSellIn(item);
                }

                
                if (SellByDateHasPassed(item))
                {
                    if (IsNotAgedBrie(item))
                    {
                        if (IsNotBackstagePass(item))
                        {
                            DecrementQuality(item);
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        if (QualityIsBelowMaximum(item))
                        {
                            IncrementQuality(item);
                        }
                    }
                }
            }
        }

        private static bool IsBackstagePass(Item item) => item.Name == "Backstage passes to a TAFKAL80ETC concert";

        private static bool IsNotSulfuras(Item item) => item.Name != "Sulfuras, Hand of Ragnaros";

        private static bool IsNotBackstagePass(Item item) => !IsBackstagePass(item);

        private static bool IsAgedBrie(Item item) => item.Name == "Aged Brie";
        
        private static bool IsNotAgedBrie(Item item) => !IsAgedBrie(item);

        private static bool SellByDateHasPassed(Item item) => item.SellIn < 0;

        private static bool AreLessThan5DaysLeft(Item item) => item.SellIn < 6;

        private static bool AreLessThan10DaysLeft(Item item) => item.SellIn < 11;

        private static bool QualityIsBelowMaximum(Item item) => item.Quality < 50;

        private static bool QualityIsAboveMinimum(Item item) => item.Quality > 0;

        private static int DecreaseSellIn(Item item) => item.SellIn -= 1;

        private static int IncrementQuality(Item item) => item.Quality += 1;

        private static int DecrementQuality(Item item)
        {
            if (IsNotSulfuras(item) && QualityIsAboveMinimum(item))
            {
                return item.Quality -= 1;    
            }

            return item.Quality;
        }
    }
}