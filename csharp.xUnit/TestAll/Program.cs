

using GildedRoseKata;

using var file = File.CreateText("/Users/davidbetteridge/Personal/GildedRose-Refactoring-Kata_2025/csharp.xUnit/GildedRoseTests/AllTests.cs");

for (var quality = 0; quality < 100; quality++)
{
    for (var sellin = 0; sellin < 100; sellin++)
    {
        var items = new List<Item>
        {
            new Item { Name = "normal", SellIn = sellin, Quality = quality },
            new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality },
            new Item { Name = "Conjured", SellIn = sellin, Quality = quality }
        };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        foreach (var item in items)
        {
            CreateTest(file, item.Name, sellin, quality, item.SellIn, item.Quality);
        }
        
    }
}

void CreateTest(StreamWriter file, string itemName, int sellin, int qualtity, int finalSellin, int finalQuality)
{ 
    file.WriteLine(" [Fact]");
    file.WriteLine($" public void {itemName.Replace(" ", "_").Replace(",","")}_{sellin}_{qualtity}()");
    file.WriteLine(" {");
    file.WriteLine("     var items = new List<Item> { new() { Name = \"" + itemName + "\", SellIn = " + sellin + ", Quality = "+qualtity+" } };");
    file.WriteLine("     var app = new GildedRose(items);");
    file.WriteLine("     app.UpdateQuality();");
    file.WriteLine($"     Assert.Equal({finalSellin}, items[0].SellIn);");
    file.WriteLine($"     Assert.Equal({finalQuality}, items[0].Quality);");
    file.WriteLine(" }  ");
    file.WriteLine();
}


