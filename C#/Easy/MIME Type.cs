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
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        
        var fileTypes = new Dictionary<string, string>();
        
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string EXT = inputs[0].ToUpper(); // file extension
            string MT = inputs[1]; // MIME type.
            fileTypes.Add(EXT,MT);
            Console.Error.WriteLine("Extension " + EXT + " associated with " + fileTypes[EXT]);
        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
            
            //Console.Error.WriteLine("Filename = " + FNAME);

            string ext = "";
            bool extension = false;
            string Fname = FNAME;
            while (Fname.Length > 0)
            {
                if(!extension) 
                {
                    if(Fname.Substring(0,1) == ".")
                        extension = true;
                }
                else
                {
                    if(Fname.Substring(0,1) == ".")
                    {
                        ext = "";
                    }
                    else
                    {
                        ext += Fname.Substring(0,1);
                    }
                }
                Fname = Fname.Substring(1);
                //Console.Error.WriteLine(FNAME);
                //Console.Error.WriteLine("ext = " + ext);
            }
            ext = ext.ToUpper();
           
           Console.Error.WriteLine("File name: " + FNAME + "; ext: " + ext);
           
            if(fileTypes.ContainsKey(ext)) 
            {
                Console.WriteLine(fileTypes[ext]);
            }
            else
            {
               Console.WriteLine("UNKNOWN");
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        //Console.WriteLine("UNKNOWN"); // For each of the Q filenames, display on a line the corresponding MIME type. If there is no corresponding type, then display UNKNOWN.
    }
}