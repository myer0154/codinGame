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
class Player
{
    struct path
    {
        public int n1;
        public int n2;
    }
    
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int N = int.Parse(inputs[0]); // the total number of nodes in the level, including the gateways
        int L = int.Parse(inputs[1]); // the number of links
        int E = int.Parse(inputs[2]); // the number of exit gateways
        
        
        
        List<int> gateways = new List<int>();
        
        List<path> paths = new List<path>();
        var connections = new Dictionary<int, List<int>>(); 
        
        for (int i = 0; i < L; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int N1 = int.Parse(inputs[0]); // N1 and N2 defines a link between these nodes
            int N2 = int.Parse(inputs[1]);
            path temp;
            temp.n1=N1;
            temp.n2=N2;
            paths.Add(temp);
        }
        
        for (int i = 0; i < E; i++)
        {
            int EI = int.Parse(Console.ReadLine()); // the index of a gateway node
            gateways.Add(EI);
        }
        
        // populate the connections from each node
        for (int i = 0; i < N; i++)
        {
           List<int> conNodes = new List<int>();
           foreach(path p in paths)
           {
               if(p.n1 == i)
               {
                   conNodes.Add(p.n2);
               }
               else if (p.n2 == i)
               {
                   conNodes.Add(p.n1);
               }
           }
           // Console.Error.WriteLine("Adding dictionary for node " + i);
           connections.Add(i, conNodes);
        }

        
        
        // game loop
        while (true)
        {
            int cut1 = 0;
            int cut2 = 0;
            bool found = false;
            
            int SI = int.Parse(Console.ReadLine()); // The index of the node on which the Skynet agent is positioned this turn

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            List<int> agentPaths = connections[SI];
            foreach (int x in agentPaths)
            {
                foreach (int exit in gateways)
                {
                    if(x == exit) 
                    {
                        cut1 = SI;
                        cut2 = x;
                        found = true;
                        //Console.Error.WriteLine("Agent exit path found between " + cut1 + " and " + cut2 + " cutting!");"
                        agentPaths.Remove(x);
                        connections[SI]=agentPaths;
                        List<int> temp = connections[x];
                        temp.Remove(SI);
                        connections[x] = temp;
                        goto next;
                    }
                }
            }
            
            
            /*if(!found)
            {
                foreach(int g in gateways)
                {
                    if(connections[g].Count > 0)
                    {
                        List<int> conNodes = connections[g];
                        cut1 = g;
                        cut2 = conNodes[0];
                        conNodes.Remove(cut2);
                        connections[g] = conNodes;
                        List<int> temp = connections[cut2];
                        temp.Remove(g);
                        connections[cut2] = temp;
                        found = true;
                        goto next;
                    }
                }
            }*/
            
            if(!found)
            {
                foreach(int x in connections[SI])
                {
                    if(connections[x].Count > 0)
                    {
                        List<int> conNodes = connections[x];
                        cut1 = x;
                        cut2 = conNodes[0];
                        conNodes.Remove(cut2);
                        connections[x] = conNodes;
                        List<int> temp = connections[cut2];
                        temp.Remove(x);
                        connections[cut2] = temp;
                        found = true;
                        goto next;
                    }
                }
            }
            
            
            next:
            Console.WriteLine(cut1 + " " + cut2); // Example: 0 1 are the indices of the nodes you wish to sever the link between
        }
    }
}