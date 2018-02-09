using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Item
{
    public int id;
    public string name;
    public int type;
    public int rarity;

    public const int GEM = 0;
    public const int METAL = 1;

    public Item()
    {

    }

    public Item(int id, string name, int type, int rarity)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.rarity = rarity;
    }
}