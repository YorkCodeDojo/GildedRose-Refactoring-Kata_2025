using GildedRoseKata;

using System.Text.Json;
using System.Threading.Tasks;

using VerifyNUnit;

using NUnit.Framework;

namespace GildedRoseTests;

public class ApprovalTest
{

    [Test, Combinatorial]
    public Task Bar(
        [Values("", "test item", "!!!00#\n", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert")] string name,
        [Values(int.MinValue, -100, -1, 0, 1, 100, int.MaxValue)] int sellIn,
        [Values(int.MinValue, -100, -1, 0, 1, 100, int.MaxValue)] int quality
    )
    {
        Item item = new() {Name = name, SellIn = sellIn, Quality = quality};

        GildedRose.UpdateItemQuality(item);
        
        return Verifier.Verify(JsonSerializer.Serialize(item));
    }
}