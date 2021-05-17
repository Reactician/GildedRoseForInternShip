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
                if(Items[i].Name!= "Sulfuras, Hand of Ragnaros")
                    Items[i].SellIn = Items[i].SellIn - 1;

                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (Items[i].SellIn < 0)
                            Items[i].Quality = 0;
                        else if (Items[i].SellIn < 5 && Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 3;
                        else if (Items[i].SellIn < 10 && Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 2;
                        else if (Items[i].Quality < 50)
                            Items[i].Quality= Items[i].Quality + 1;
                        break;
                    case "Aged Brie": 
                        if (Items[i].Quality < 50 && Items[i].SellIn < 0)
                            Items[i].Quality = Items[i].Quality + 2;
                        else if (Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 1;
                        break;
                    case "Conjured Mana Cake":
                        if (Items[i].Quality > 0 && Items[i].SellIn >= 0)
                            Items[i].Quality = Items[i].Quality - 2;
                        else if (Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 4;
                        /*twice as faster, so instead of 1 its 2 while it's not
                         past the SellIn and after would the twice would be 4 instead of 2*/
                        break;
                    default:
                        if (Items[i].Quality > 0 && Items[i].SellIn >= 0)
                            Items[i].Quality = Items[i].Quality - 1;
                        else if(Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 2;
                        break;
                        /*easier to add new unique items now, 
                        other than that its pretty much the same, although switches should be faster*/
                }
                if (Items[i].Quality > 50 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    Items[i].Quality = 50;

            }
        }
    }
}