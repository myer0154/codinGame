using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Node
{
    public int ID;
    List<Node> links;
    public bool origin;
    int followedLinkCounter;
    
    public int LinkCount {get {return links.Count;}}
    
    public bool CanFollow() 
    {
        if(followedLinkCounter <= links.Count-1)
            return true;
        else
            return false;
    }
    
    public Node(int id)
    {
        ID = id;
        links = new List<Node>();
        origin = true;
        followedLinkCounter = 0;
    }
    
    public void AddLink(Node n)
    {
        links.Add(n);
    }
    
    public Node FollowLink()
    {
        Node temp = links[followedLinkCounter];
        // links.RemoveAt(0);
        followedLinkCounter++;
        return temp;
    }
    
    public void ResetLinks()
    {
        followedLinkCounter = 0;
    }
}


class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // the number of relationships of influence
        var nodeList = new Dictionary<int, Node>(N+1);
        //Node baseNode = new Node(0);
        
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int x = int.Parse(inputs[0]); // a relationship of influence between two people (x influences y)
            int y = int.Parse(inputs[1]);
            Console.Error.WriteLine(x + " -> " + y);
            
            // if either Node does not exist, make one
            if(!nodeList.ContainsKey(x))
            {
                Node nodeX = new Node(x);
                nodeList.Add(x, nodeX);
            }
            if(!nodeList.ContainsKey(y))
            {
                Node nodeY = new Node(y);
                nodeList.Add(y, nodeY);
            }
            nodeList[x].AddLink(nodeList[y]);
            nodeList[y].origin = false;
        }
        
        Stack<Node> nodeStack = new Stack<Node>();
        int count = 0;
        int maxCount = 0;
        Console.Error.WriteLine("******");
        foreach(Node n in nodeList.Values)
        {
            if(n.origin)
            {
                //Console.WriteLine("Node " + n.ID + " is an origin");
                nodeStack.Clear();
                count = 1;
                Node curNode = n;
                Console.Error.WriteLine("Beginning with node " + n.ID);
                while(curNode.CanFollow())
                {
                    nodeStack.Push(curNode);
                    count++;
                    if(count > maxCount)
                        maxCount = count;
                    Console.Error.Write("Following link from " + curNode.ID + " to ");
                    curNode = curNode.FollowLink();
                    Console.Error.WriteLine(curNode.ID);
                    while(!curNode.CanFollow())
                    {
                        Console.Error.WriteLine("Reached end at Node " + curNode.ID + "; count = " + count);
                        if(nodeStack.Count == 0) {
                            Console.Error.WriteLine("Stack fully unwound");
                            break;
                        }
                        // reset the link status for the abandoned node, so it can be traced again
                        curNode.ResetLinks();
                        curNode = nodeStack.Pop();
                        Console.Error.WriteLine("Returning to node " + curNode.ID);
                        count--;
                       
                    }
                }
            }
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(maxCount); // The number of people involved in the longest succession of influences
    }
}