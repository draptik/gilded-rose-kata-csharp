namespace GildedRose.Products
{
    public class Conjured : BaseItem, IItemBehaviour
    {
        public Conjured(Item item) : base(item)
        {
        }

        public void Iterate()
        {
            Item.DecrementQuality();
            Item.DecrementQuality();
            
            Item.DecreaseSellIn();

            if (Item.SellByDateHasPassed())
            {
                Item.DecrementQuality();
                Item.DecrementQuality(); // <-- Not sure if I understood the requirement correctly
            }
        }
    }
}