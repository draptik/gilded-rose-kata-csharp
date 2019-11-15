using System;

namespace GildedRose.Products
{
    public abstract class BaseItem
    {
        protected BaseItem(Item item)
        {
            Item = item ?? throw new Exception("Item must not be null!");
        }

        protected Item Item { get; }
        
        public override string ToString() => Item.ToString();
    }
}