using GildedRoseKata;

using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using VerifyXunit;

using Xunit;

namespace GildedRoseTests;

public class ApprovalTest
{
    [Fact]
    public Task AllValues()
    {
        var sb = new StringBuilder();
        
        for (var quality = 0; quality < 100; quality++)
        {
            for (var sellin = 0; sellin < 100; sellin++)
            {
                var items = new List<Item>
                {
                    new() { Name = "normal", SellIn = sellin, Quality = quality },
                    new() { Name = "Aged Brie", SellIn = sellin, Quality = quality },
                    new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality },
                    new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality },
                    new() { Name = "Conjured", SellIn = sellin, Quality = quality }
                };
                GildedRose app = new GildedRose(items);
                app.UpdateQuality();

                foreach (var item in items)
                {
                    sb.AppendLine($"Name: {item.Name}   Sellin: {item.SellIn}   Quality: {item.Quality}");
                }
            }
        }
        
        return Verifier.Verify(sb.ToString());
    }
}