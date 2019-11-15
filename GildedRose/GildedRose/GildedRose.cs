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
                if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (QualityIsAboveMinimum(item))
                    {
                        if (item.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            DecrementQuality(item);
                        }
                    }
                }
                else
                {
                    if (QualityIsBelowMaximum(item))
                    {
                        IncrementQuality(item);

                        if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
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

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    DecreaseSellIn(item);
                }

                if (SellByDateHasPassed(item))
                {
                    if (item.Name != "Aged Brie")
                    {
                        if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (QualityIsAboveMinimum(item))
                            {
                                if (item.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    DecrementQuality(item);
                                }
                            }
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

        private static bool SellByDateHasPassed(Item item) => item.SellIn < 0;

        private static bool AreLessThan5DaysLeft(Item item) => item.SellIn < 6;

        private static bool AreLessThan10DaysLeft(Item item) => item.SellIn < 11;

        private static bool QualityIsBelowMaximum(Item item) => item.Quality < 50;

        private static bool QualityIsAboveMinimum(Item item) => item.Quality > 0;

        private static int DecreaseSellIn(Item item) => item.SellIn -= 1;

        private static int IncrementQuality(Item item) => item.Quality += 1;

        private static int DecrementQuality(Item item) => item.Quality -= 1;
    }
}