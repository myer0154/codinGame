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
        int n = int.Parse(Console.ReadLine());
        
        int[] values = new int[n];
        Console.Error.WriteLine("Has " + n + " values listed");
        
        string[] inputs = Console.ReadLine().Split(' ');
        for (int i = 0; i < n; i++)
        {
            values[i] = int.Parse(inputs[i]);
            Console.Error.Write(values[i] + " ");
        }
        Console.Error.Write("\n");
        
        int maxLoss = 0;
        int localMinIndex = 0;
        int localMaxIndex = 0;
        
        //Console.Error.WriteLine("*** New local max: " + values[localMaxIndex] + " (element " + localMaxIndex + ") ***");
        
        for(int i = 0; i < values.Length; i++)
        {
            // every time we hit a new local peak, start another region
            if(values[i] > values[localMaxIndex])
            {
                //Console.Error.WriteLine("*** New local max: " + values[i] + " (element " + i + ")***");
                localMaxIndex = i;
                localMinIndex = i;
            }
            
            // if we've hit a new local min, compare to the losses so far
            if(values[i] < values[localMinIndex])
            {
                //Console.Error.WriteLine("New local min: " + values[i] + " (element " + i + ")");
                int loss = values[i] - values[localMaxIndex];
                if(loss < maxLoss)
                    maxLoss = loss;
                //Console.Error.WriteLine("Loss = " + loss + "; maxLoss = " + maxLoss);
                localMinIndex = i;
            }
        }
                
                
            // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(maxLoss);
    }
}