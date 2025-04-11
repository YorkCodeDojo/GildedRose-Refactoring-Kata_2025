using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    private const string AgedBrie = "Aged Brie";
    private const string BackstagePassesToATafkal80EtcConcert = "Backstage passes to a TAFKAL80ETC concert";
    private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
    
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            UpdateItemQuality(item);
        }
    }

    public static void UpdateItemQuality(Item item)
    {
        switch (item.Name)
        {
            case AgedBrie:
                UpdateAgedBrie(item);
                break;
            case BackstagePassesToATafkal80EtcConcert:
            {
                UpdateBackstagePass(item);
                break;
            }
            case SulfurasHandOfRagnaros:
                break;
            default:
            {
                UpdateDefault(item);
                break;
            }
        }
    }

    private static void UpdateBackstagePass(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;

            if (item.SellIn < 11)
            {
                IncrementQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncrementQuality(item);
            }
        }
                
        DecrementBackstagePassSellIn(item);
    }

    private static void UpdateAgedBrie(Item item)
    {
        IncrementQuality(item);

        item.SellIn -= 1;

        if (item.SellIn >= 0) return;
        
        IncrementQuality(item);
    }

    private static void UpdateDefault(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }
                
        item.SellIn -= 1;
                    
        if (item.SellIn >= 0 || item.Quality <= 0) return;
                    
        item.Quality -= 1;
    }

    private static void IncrementQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

    private static void DecrementBackstagePassSellIn(Item item)
    {
        item.SellIn -= 1;
        
        if (item.SellIn < 0)
            item.Quality = 0;
    }
}