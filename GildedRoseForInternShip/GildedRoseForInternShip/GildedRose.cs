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
                //all items decrease in SellIn value every day, so to not repeat it everywhere,
                //i wrote it here
                switch (Items[i].Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        //this item does not change, so theres just a break here
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
                        //goes to 0 once the concert is over, 
                        //increases in quality by 3 if SellIn value is 5 days or less,
                        //increases in quality by 2 if SellIn value is 10 days or less,
                        //increases in quality by 1 if SellIn value is more than 10
                        break;
                    case "Aged Brie": 
                        if (Items[i].Quality < 50 && Items[i].SellIn < 0)
                            Items[i].Quality = Items[i].Quality + 2;
                        else if (Items[i].Quality < 50)
                            Items[i].Quality = Items[i].Quality + 1;
                        //goes up by 2 in quality once the sell date has passed, 
                        //otherwise goes up by 1 in quality
                        break;
                    case "Conjured Mana Cake":
                        if (Items[i].Quality > 0 && Items[i].SellIn >= 0)
                            Items[i].Quality = Items[i].Quality - 2;
                        else if (Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 4;
                        //Conjured Items decrease in value twice as fast as regular items
                        break;
                    default:
                        if (Items[i].Quality > 0 && Items[i].SellIn >= 0)
                            Items[i].Quality = Items[i].Quality - 1;
                        else if(Items[i].Quality > 0)
                            Items[i].Quality = Items[i].Quality - 2;
                        break;
                        //default case for all the other items that don't have unique properties,
                        //decreases value by 1 if SellIn value is not below 0,
                        //decreases value by 2(twice as fast) otherwise.
                }
                if (Items[i].Quality > 50 && Items[i].Name != "Sulfuras, Hand of Ragnaros")
                    Items[i].Quality = 50;
                //for "Aged Brie" and "Backstage passes" to not go over the quality maximum limit

            }
        }
    }
}