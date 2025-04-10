using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose(IList<Item> items)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            UpdateItem(item);
        }
    }

    private void UpdateItem(Item item)
    {
        switch (item.Name)
        {
            case "Aged Brie":
                UpdateAgedBrie(item);
                break;
            case "Backstage passes to a TAFKAL80ETC concert":
                UpdateBackstagePasses(item);
                break;
            case "Sulfuras, Hand of Ragnaros":
                UpdateSulfuras(item);
                break;
            case "Conjured":
                UpdateConjured(item);
                break;
            default:
                UpdateNormalItem(item);
                break;
        }
    }

    private static void UpdateNormalItem(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }

    private static void UpdateConjured(Item item)
    {
        if (item.Quality > 1)
        {
            item.Quality -= 2;
        }
        else if (item.Quality > 0)
        {
            item.Quality -= 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality > 1)
            {
                item.Quality -= 2;
            }
            else if (item.Quality > 0)
            {
                item.Quality -= 1;
            }
        }
    }
    
    private void UpdateSulfuras(Item item)
    {
    }

    private void UpdateBackstagePasses(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality += 1;
                }
            }
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            item.Quality = 0;
        }
    }

    private void UpdateAgedBrie(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }

        item.SellIn -= 1;

        if (item.SellIn < 0)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
    }
}