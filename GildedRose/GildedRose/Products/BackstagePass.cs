namespace GildedRose.Products
{
    public class BackstagePass : BaseItem, IItemBehaviour
    {
        public BackstagePass(Item item) : base(item)
        {
        }

        public void Iterate()
        {
            IncreaseQuality();

            Item.DecreaseSellIn();

            if (Item.SellByDateHasPassed())
            {
                Item.Quality = 0;
            }
        }

        private void IncreaseQuality()
        {
            Item.IncrementQuality();

            if (Item.AreLessThan10DaysLeft())
            {
                Item.IncrementQuality();
            }

            if (Item.AreLessThan5DaysLeft())
            {
                Item.IncrementQuality();
            }
        }
    }
}