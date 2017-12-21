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
    static Dictionary<int, string[]> DefineValues(int L, int H, string[] rawLines)
    {
        var numerals = new Dictionary<int, string[]>(20);
        for(int i = 0; i < 20; i++)
        {
            // create and fill the string array for the number
            string[] lines = new string[H];
            for(int j = 0; j < H; j++)
            {
                lines[j] = rawLines[j].Substring(i*L,L);
            }
            
            numerals.Add(i, lines);
        }
        
        return numerals;
    }
    
    static long ParseNumber(string[] lines, Dictionary<int, string[]> reference)
    {
        int linesPerSymbol = reference[0].Length;
        //Console.Error.WriteLine( linesPerSymbol + " lines per symbol");
        int power = (lines.Length/linesPerSymbol)-1;
        
        long value = 0;
        int lineNum = 0;
        
        while(power >= 0)
        {
            string[] character = new string[linesPerSymbol];
            for(int i = lineNum; i < lineNum + linesPerSymbol; i++)
            {
                character[i-lineNum] = lines[i];
            }
            //Console.Error.WriteLine("Parsing this character:");
            int baseVal = 0;
            foreach(KeyValuePair<int, string[]> entry in reference)
            {
                bool match = true;
                for(int j = 0; j < linesPerSymbol; j++)
                {
                    if(character[j] != entry.Value[j])
                    {
                        match = false;
                        break;
                    }
                }
                if(match) {
                    baseVal = entry.Key;
                    //Console.Error.WriteLine("Matched symbol to " + entry.Key);
                }
            }
            
            value += baseVal * (long)Math.Pow(20, power);
            power--;
            lineNum += linesPerSymbol;
        }
        
        
        
        return value;
    }
    
    static string[] ReverseParse(long value, Dictionary<int, string[]> reference)
    {
        Console.Error.WriteLine("Converting " + value + " to symbol:");
        int linesPerSymbol = reference[0].Length;
        int power = 0;
        while(value > (long)Math.Pow(20, power+1))
        {
            power++;
        }
        string[] output = new string[(power+1)*linesPerSymbol];
        int lineNum = 0;
        while(power >= 0)
        {
            int baseVal = (int)(value / (long)Math.Pow(20, power));
            Console.Error.WriteLine("Value = " + value + "; baseVal = " + baseVal + " x20^" + power);
            value -= (long)(baseVal*Math.Pow(20,power));
            string[] baseChar = reference[baseVal];
            for(int i = 0; i < linesPerSymbol; i++)
            {
                output[lineNum + i] = baseChar[i];
            }
            power--;
            lineNum += linesPerSymbol;
        }
        
        foreach(string s in output)
        {
            Console.Error.WriteLine(s);
        }
        
        return output;
    }
    
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        
        string[] refLines = new string[H];
        
        
        for (int i = 0; i < H; i++)
        {
            refLines[i] = Console.ReadLine();
        }
        
        int S1 = int.Parse(Console.ReadLine());
        string[] num1 = new string[S1];
        //Console.Error.WriteLine("Number 1:");
        for (int i = 0; i < S1; i++)
        {
            num1[i] = Console.ReadLine();
            //Console.Error.WriteLine(num1[i]);
        }
        
        int S2 = int.Parse(Console.ReadLine());
        string[] num2 = new string[S2];
        for (int i = 0; i < S2; i++)
        {
            num2[i] = Console.ReadLine();
        }
        string operation = Console.ReadLine();

        Dictionary<int, string[]> values = DefineValues(L,H, refLines);
        
        /*foreach(KeyValuePair<int, string[]> entry in values)
        {
            Console.Error.WriteLine(entry.Key + ":");
            foreach(string s in entry.Value)
            {
                Console.Error.WriteLine(s);
            }
            Console.Error.WriteLine();
        }*/
        
        long n1 = ParseNumber(num1,values);
        long n2 = ParseNumber(num2, values);
        long result = 0;
        if(operation == "+")
            result = n1 + n2;
        else if(operation == "-")
            result = n1 - n2;
        else if(operation == "*")
            result = n1 * n2;
        else if(operation == "/")
            result = n1/n2;
        
        string[] resultS = ReverseParse(result, values);
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        foreach(string s in resultS)
        {
            Console.WriteLine(s);
        }
        //Console.WriteLine("result");
    }
}