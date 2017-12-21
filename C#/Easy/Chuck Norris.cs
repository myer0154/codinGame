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
        string MESSAGE = Console.ReadLine();

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        string bin = "";
        
        Console.Error.WriteLine("Message = " + MESSAGE);
        
        for(int i = 0; i < MESSAGE.Length; i++)
        {
            string letter = MESSAGE.Substring(i,1);
            byte[] asciiLets = Encoding.ASCII.GetBytes(MESSAGE);
            Console.Error.WriteLine("letter = " + letter);
            Console.Error.WriteLine("value = " + asciiLets[i]);
            string letterBin = Convert.ToString(Convert.ToInt32(asciiLets[i].ToString(),10),2);
            while (letterBin.Length < 7)
            {
                letterBin = "0" + letterBin;
            }
            bin += letterBin;
            Console.Error.WriteLine("Bin value = " + bin);
        }
        
        string lastVal = "";
        string code = "";
        
        for (int i = 0; i < bin.Length; i++)
        {
            string digit = bin.Substring(i,1);
            if(digit == lastVal) {
                code += "0";
            }
            else if (digit != lastVal)
            {
                if(lastVal != "")
                    code += " ";
                    
                lastVal = digit;
                if(digit == "0") {
                    code += "00 0";
                }
                else if (digit == "1") {
                    code += "0 0";
                }
                else Console.Error.WriteLine("Digit is not 1 or 0: " + digit);
            }
            else {
                Console.Error.WriteLine("*** Something weird happened ***");
            }
            
        }
        
        //Console.Error.WriteLine(code);
        
        Console.WriteLine(code);
    }
}