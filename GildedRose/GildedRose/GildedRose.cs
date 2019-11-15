using System.Collections.Generic;

namespace GildedRose
{
    public class Sulfuras : BaseItem, IItemBehaviour
    {
        public Sulfuras(Item item)
        {
            Item = item;
        }

        public void Iterate()
        {
        }
    }

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
        
        public override string ToString() => Item.ToString();
    }
    
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
                var concreteItem = ItemFactory.ToConcreteItem(item);
                concreteItem.Iterate();
            }
        }
    }
}