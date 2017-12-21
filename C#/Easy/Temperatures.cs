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
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string temps = Console.ReadLine(); // the n temperatures expressed as integers ranging from -273 to 5526

        string[] tokens = temps.Split(' ');
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
        
        int minTemp = 5526;
        
        Console.Error.WriteLine(temps);
        
        if(n == 0)
            minTemp = 0;
        
        int[] tempList = new int[n];
        for (int i = 0; i < n; i++)
        {
            tempList[i] = int.Parse(tokens[i]);
            // read a value
            if(Math.Abs(tempList[i]) < Math.Abs(minTemp)) {
                minTemp = tempList[i];
            }
            else if(Math.Abs(tempList[i]) == Math.Abs(minTemp) && tempList[i] > 0) {
                minTemp = tempList[i];
            }
            Console.Error.WriteLine("New min temp = " + minTemp);
                
        }
        

        Console.WriteLine(minTemp);
    }
}