namespace GildedRose.Products
{
    public class Conjured : BaseItem, ICanIterate
    {
        public Conjured(Item item) : base(item)
        {
        }

        /// <summary>
        /// The business rule states:
        /// 
        ///     "`Conjured` degrade in Quality twice as fast as normal items"
        ///
        /// We currently do not have any reference to `NormalItem`.
        /// </summary>
        public void Iterate()
        {
            Item.DecrementQuality();
            Item.DecrementQuality(); // <-- "twice"
            
            Item.DecreaseSellIn();

            if (Item.SellByDateHasPassed())
            {
                Item.DecrementQuality();
                Item.DecrementQuality(); // <-- Not sure if I understood the requirement correctly
            }
        }
    }
}