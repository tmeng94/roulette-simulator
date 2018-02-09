using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Prize
{
    public Item item;
    public int rate;
    public Roulette secondChance;

    public Prize()
    {

    }

    public Prize(Item item, int rate, Roulette secondChance = null)
    {
        this.item = item;
        this.rate = rate;
        this.secondChance = secondChance;
    }
}