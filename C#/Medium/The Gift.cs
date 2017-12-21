using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int cost = int.Parse(Console.ReadLine());
        //Console.Error.WriteLine("Cost = " + cost);
        //Console.Error.WriteLine("*** Budgets: ***");
        
        List<int> budgets = new List<int>(N);
        List<int> costs = new List<int>(N);
        
        // Add the budgets to that list and initialize the costs list to zeros
        for (int i = 0; i < N; i++)
        {
            int B = int.Parse(Console.ReadLine());
            budgets.Add(B);
            costs.Add(0);
            //Console.Error.WriteLine(B);
        }
        
        

        while(cost > 0)
        {
            int maxedBudgetCount = 0;
            int averageCost = cost/(N - maxedBudgetCount);
            
            //Console.Error.WriteLine("Cost remaing = " + cost + "; average over " + N + " = " + averageCost + " (" + (cost-averageCost*N) + ") leftover");
            if(averageCost == 0 && cost != 0)
                averageCost++;
            
            for(int i = 0; i < N; i++)
            {
                if(cost==0)
                    break;
                
                if(budgets[i] >= costs[i] + averageCost)
                {
                    costs[i] += averageCost;
                    cost -= averageCost;
                    //Console.Error.WriteLine("Set cost " + i + " to " + costs[i]);
                }
                else
                {
                    int oldCost = costs[i];
                    costs[i] = budgets[i];
                    cost -= (costs[i] - oldCost);
                    maxedBudgetCount++;
                    //Console.Error.WriteLine("Budget " + i + " is maxed at " + costs[i]);
                }
                
                if(maxedBudgetCount == N)
                {
                    Console.WriteLine("IMPOSSIBLE");
                    return;
                }
            }
        }
        
        //Console.Error.WriteLine("*** Costs: ***");
        
        costs.Sort();
        foreach(int i in costs)
        {
            Console.WriteLine(i);
        }
        
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        //Console.WriteLine("IMPOSSIBLE");
    }
}