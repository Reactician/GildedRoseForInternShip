using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {

            for (var i = 0; i < Items.Count; i++)
            {
                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (Items[i].SellIn < 0)
                            Items[i].Quality = 0;
                        else if (Items[i].SellIn < 5 && Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 3;
                        else if (Items[i].SellIn < 11 && Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 2;
                        Items[i].SellIn = Items[i].SellIn - 1;
                        break;
                    case "Aged Brie":
                        Items[i].SellIn = Items[i].SellIn - 1;
                        if (Items[i].Quality < 50 && Items[i].SellIn < 0)
                            Items[i].Quality = Items[i].Quality + 2;
                        else if (Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 1;
                        break;
                    case "Conjured Mana Cake":
                        Items[i].SellIn = Items[i].SellIn - 1;
                        if (Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 2;
                        /*twice as faster, so instead of one its two*/
                        break;
                    default:
                        Items[i].SellIn = Items[i].SellIn - 1;
                        if (Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 1;
                        break;
                        /*easier to add new unique items now, 
                        other than that its pretty much the same, although switches should be faster*/
                }

            }
        }
    }
}