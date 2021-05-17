using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void TestForRegularItem()
        {
            IList<Item> Items = new List<Item> { new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(19, Items[0].Quality);
        }

        [Test]
        public void TestForRegularItemAfterSellInDatePass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = -1, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(18, Items[0].Quality);
        }
        [Test]
        public void TestForAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item {Name = "Aged Brie", SellIn = 2, Quality = 0}};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(1, Items[0].Quality);
        }
        [Test]
        public void TestForMoreAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
        }
        [Test]
        public void TestForMaxQualityAgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void TestForSulfurasHandOfRagnaros()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void TestForBackStagePasses()
        {
            IList<Item> Items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                }}; 
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(14, Items[0].SellIn);
            Assert.AreEqual(21, Items[0].Quality);
        }

        [Test]
        public void TestForBackStagePassesOverDayEleven()
        {
            IList<Item> Items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20
                }};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(22, Items[0].Quality);
        }

        [Test]
        public void TestForBackStagePassesOverDaySix()
        {
            IList<Item> Items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                }};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(23, Items[0].Quality);
        }

        [Test]
        public void TestForBackStagePassesAfterTheConcert()
        {
            IList<Item> Items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 20
                }};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void TestForBackStagePassesOverTheQuality()
        {
            IList<Item> Items = new List<Item> { new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 49
                }};
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void TestForConjuredManaCake()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(4, Items[0].Quality);
        }

        [Test]
        public void TestForConjuredManaCakeAfterSellInDatePass()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-2, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);
        }
    }
}