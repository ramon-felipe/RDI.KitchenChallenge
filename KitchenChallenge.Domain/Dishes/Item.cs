using KitchenChallenge.Domain.Enums;

namespace KitchenChallenge.Domain.Dishes
{
    public class Item
    {
        public ItemType Type { get; set; }
        public ItemSizeEnum Size { get; set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public void SetItemDescription(string desc)
        {
            Description = desc;
        }

        public void SetItemPrice(decimal price)
        {
            Price = price;
        }
    }
}
