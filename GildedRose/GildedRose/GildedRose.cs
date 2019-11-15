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
                            if (item.SellIn < 11)
                            {
                                if (QualityIsBelowMaximum(item))
                                {
                                    IncrementQuality(item);
                                }
                            }

                            if (item.SellIn < 6)
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

                if (item.SellIn < 0)
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

        private static bool QualityIsBelowMaximum(Item item) => item.Quality < 50;

        private static bool QualityIsAboveMinimum(Item item) => item.Quality > 0;

        private static int DecreaseSellIn(Item item) => item.SellIn -= 1;

        private static int IncrementQuality(Item item) => item.Quality += 1;

        private static int DecrementQuality(Item item) => item.Quality -= 1;
    }
}