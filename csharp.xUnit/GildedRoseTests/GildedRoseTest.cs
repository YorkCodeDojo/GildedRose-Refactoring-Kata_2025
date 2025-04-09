using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void NormalItemDecreases()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 3 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(1, Items[0].SellIn);
        Assert.Equal(2, Items[0].Quality);
    }
    
    [Fact]
    public void SellByDatePassed()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 6 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal(-1, Items[0].SellIn);
        Assert.Equal(4, Items[0].Quality);
    }
}