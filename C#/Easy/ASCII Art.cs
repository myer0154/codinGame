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
        int L = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        string T = Console.ReadLine();
        
        var asciiLets = new Dictionary<string, string[]>();
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ?";
        string output = "";
        
        for(int i = 0; i < letters.Length; i++)
        {
            asciiLets.Add(letters.Substring(i,1), new string[H]);
        }
        
        for (int i = 0; i < H; i++)
        {
            string ROW = Console.ReadLine();
            Console.Error.WriteLine("i = " + i);
            int n = 0;
            while (ROW.Length > 0)
            {
                //Console.Error.WriteLine("ROW = " + ROW);
                string letter = letters.Substring(n,1);
                //Console.Error.WriteLine("letter = " + letter);
                asciiLets[letter][i] = ROW.Substring(0, L);
                //Console.Error.WriteLine("Row " + i + " = " + ROW.Substring(0, L));
                ROW = ROW.Substring(L);
                n++;
            }
        }
        
        
        
        for (int i = 0; i < H; i++)
        {
            for (int n = 0; n < T.Length; n++)
            {
                string character = T.Substring(n,1).ToUpper();
                if (asciiLets.ContainsKey(character)) {
                    output += asciiLets[character][i];
                }
                else {
                    output += asciiLets["?"][i];
                }
            }
            output += Environment.NewLine;
            //Console.Error.WriteLine("output = " + output);
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output);
        
    }
}