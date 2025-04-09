

using GildedRoseKata;

using var file = File.CreateText("/Users/davidbetteridge/Personal/GildedRose-Refactoring-Kata_2025/csharp.xUnit/TestAll/changed.txt");

for (var quality = 0; quality < 100; quality++)
{
    for (var sellin = 0; sellin < 100; sellin++)
    {
        var items = new List<Item>
        {
            new Item { Name = "normal", SellIn = sellin, Quality = quality },
            new Item { Name = "Aged Brie", SellIn = sellin, Quality = quality },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellin, Quality = quality },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellin, Quality = quality }
        };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();

        foreach (var item in items)
        {
            file.WriteLine($"Name: {item.Name}   Sellin: {item.SellIn}   Quality: {item.Quality}");
        }
    }
}



