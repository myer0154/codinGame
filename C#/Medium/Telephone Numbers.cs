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
 
class Node
{
     Dictionary<string, Node> links = new Dictionary<string, Node>();
     
     public Node GetLinkedNode(string value)
     {
         if(links.ContainsKey(value))
            return links[value];
        else
            return null;
     }
     
     public void AddLink(string value, Node node)
     {
         links.Add(value, node);
     }
     
     public bool HasLink(string value)
     {
         return links.ContainsKey(value);
     }
}
 
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        //Console.Error.WriteLine(N + " numbers to parse");
        string[] nums = new string[N];
        
        for (int i = 0; i < N; i++)
        {
            nums[i] = Console.ReadLine();
            //Console.Error.WriteLine(nums[i]);
        }

        List<Node> nodesUsed = new List<Node>();
        Node baseNode = new Node();
        Node curNode;
        
        for(int i =0; i < nums.Length; i++)
        {
            curNode = baseNode;
            for(int j = 0; j < nums[i].Length; j++)
            {
                string digit = nums[i].Substring(j,1);
                if(curNode.HasLink(digit))
                {
                    curNode = curNode.GetLinkedNode(digit);
                    //Console.Error.WriteLine("Node for " + digit + " already exists. Moving there.");
                }
                else
                {
                    Node temp = new Node();
                    curNode.AddLink(digit, temp);
                    nodesUsed.Add(temp);
                    curNode = temp;
                    //Console.Error.WriteLine("No node for " + digit +". Creating one.");
                }
            }
        }
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(nodesUsed.Count); // The number of elements (referencing a number) stored in the structure.
    }
}