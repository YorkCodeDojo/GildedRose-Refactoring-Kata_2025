using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTests
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
    public void Conjured()
    {
        var items = new List<Item> { new() { Name = "Conjured", SellIn = 3, Quality = 6 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(2, items[0].SellIn);
        Assert.Equal(4, items[0].Quality);
    }
    
    [Fact]
    public void Conjured_PastSellBy()
    {
        var items = new List<Item> { new() { Name = "Conjured", SellIn = 0, Quality = 6 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(2, items[0].Quality);
    }
    
    [Fact]
    public void Conjured_PastSellBy_NotNegative()
    {
        var items = new List<Item> { new() { Name = "Conjured", SellIn = 0, Quality = 1 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }
}