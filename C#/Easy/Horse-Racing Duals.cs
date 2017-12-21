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
        
        List<int> strengths = new List<int>();
        
        for (int i = 0; i < N; i++)
        {
            strengths.Add(int.Parse(Console.ReadLine()));
        }
        
        strengths.Sort();
        
        int lowest = int.MaxValue;
        
        for (int i = 1; i < N; i++)
        {
            if(strengths[i] - strengths[i-1] < lowest)
                lowest = strengths[i] - strengths[i-1];
            //Console.Error.WriteLine(strengths[i]);
        }
        
        

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(lowest);
    }
}