using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Util
/// </summary>
public static class Util
{
    public static Dictionary<int, string> itemTypes = new Dictionary<int, string>()
    {
        {0, "GEM"},
        {1, "METAL"}
    };

    public static Dictionary<int, Item> items = new Dictionary<int, Item>()
    {
        {100001, new Item(100001, "Ruby", Item.GEM, 5) },
        {100002, new Item(100002, "Sapphire", Item.GEM, 5) },
        {100003, new Item(100003, "Emerald", Item.GEM, 4) },
        {200001, new Item(200001, "Gold", Item.METAL, 5) },
        {200002, new Item(200002, "Silver", Item.METAL, 4) },
        {200003, new Item(200003, "Copper", Item.METAL, 3) },
        {200004, new Item(200004, "Iron", Item.METAL, 2) },
        {200005, new Item(200005, "Tin", Item.METAL, 1) },
        {200006, new Item(200006, "Platinum", Item.METAL, 5) },
        {201001, new Item(201001, "Aluminum", Item.METAL, 3) },
        {201002, new Item(201002, "Chromium", Item.METAL, 4) },
        {201003, new Item(201003, "Titanium", Item.METAL, 4) },
        {201004, new Item(201004, "Beryllium", Item.METAL, 2) },
        {201005, new Item(201005, "Vanadium", Item.METAL, 5) }
    };

    public static Roulette roulette = new Roulette(new List<Prize>() {
        new Prize(items[100001], 2, new Roulette(new List<Prize>() {
            new Prize(items[201001], 12),
            new Prize(items[201002], 5)
        })),
        new Prize(items[100002], 2, new Roulette(new List<Prize>() {
            new Prize(items[201001], 10),
            new Prize(items[200004], 4),
            new Prize(items[201003], 1)
        })),
        new Prize(items[100003], 3, new Roulette(new List<Prize>() {
            new Prize(items[201002], 4),
            new Prize(items[201004], 8),
            new Prize(items[201005], 1)
        })),
        new Prize(items[200001], 2),
        new Prize(items[200002], 4),
        new Prize(items[200003], 7),
        new Prize(items[200004], 15),
        new Prize(items[200005], 24)
    });

    public static Dictionary<int, int> results = new Dictionary<int, int>();

    public static string SpinRoulette()
    {
        var roulette_type = "Normal Roulette";
        var new_item = roulette.Spin();
        if (new_item.type == Item.GEM && results.ContainsKey(new_item.id))
        {
            roulette_type = "2nd-Chance Roulette of " + new_item.name;
            new_item = roulette.SecondChanceSpin(new_item.id);
        }
        if (new_item != null)
        {
            if (results.ContainsKey(new_item.id)) results[new_item.id] += 1;
            else results.Add(new_item.id, 1);
        }
        else
        {
            Console.WriteLine("spinRoulette: ERROR: Spin failed!");
        }
        return ("Got " + new_item.name + " from " + roulette_type + "!");
    }
}