namespace GildedRose.Products
{
    public abstract class BaseItem
    {
        protected BaseItem(Item item)
        {
            Item = item;
        }

        protected Item Item { get; }
        
        public override string ToString() => Item.ToString();
    }
}