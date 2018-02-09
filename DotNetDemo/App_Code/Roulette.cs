using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Roulette
{
    public List<Prize> prizes;
    Random random;

    public Roulette(List<Prize> prizes = null)
    {
        this.prizes = prizes;
        this.random = new Random();
    }

    public void AddPrize(Prize prize)
    {
        this.prizes.Add(prize);
    }

    public int GetTotalRate()
    {
        int totalRate = 0;
        foreach (Prize prize in prizes)
        {
            totalRate += prize.rate;
        }
        return totalRate;
    }

    public Item Spin()
    {
        if (this.prizes.Count != 0)
        {
            int target = (int)(this.random.NextDouble() * this.GetTotalRate());
            int sum = 0;
            foreach (Prize prize in this.prizes)
            {
                sum += prize.rate;
                if (sum > target)
                {
                    return prize.item;
                }
            }
            Console.WriteLine("spin: ERROR: Target not found in roulette!");
            return null;
        }
        else
        {
            Console.WriteLine("spin: No prizes in roulette!");
            return null;
        }
    }

    public Item SecondChanceSpin(int id)
    {
        if (this.prizes.Count != 0)
        {
            foreach (Prize prize in this.prizes)
            {
                if (prize.item.id == id)
                {
                    return prize.secondChance.Spin();
                }
            }
            Console.WriteLine("secondChanceSpin: No this prize in roulette! " + id);
            return null;
        }
        else
        {
            Console.WriteLine("secondChanceSpin: No prizes in roulette!");
            return null;
        }
    }

    public double Percentage(int id)
    {
        if (this.prizes.Count != 0)
        {
            foreach (Prize prize in this.prizes)
            {
                if (prize.item.id == id)
                {
                    return prize.rate / this.GetTotalRate();
                }
            }
            Console.WriteLine("percentage: No this prize in roulette! " + id);
            return 0;
        }
        else
        {
            Console.WriteLine("percentage: No prizes in roulette!");
            return 0;
        }
    }
}