using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Don't let the machines win. You are humanity's last hope...
 **/
class Node
{
    public int x = -1;
    public int y = -1;
    public int rightX = -1;
    public int rightY = -1;
    public int downX = -1;
    public int downY = -1;
}

class Player
{
    static void Main(string[] args)
    {
        int width = int.Parse(Console.ReadLine()); // the number of cells on the X axis
        int height = int.Parse(Console.ReadLine()); // the number of cells on the Y axis
        
        bool[,] grid = new bool[width,height];
        
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine(); // width characters, each either 0 or .
            for(int j = 0; j < line.Length; j++)
            {
                if(line.Substring(j,1) == ".") {
                    grid[j,i] = false;
                }
                else if(line.Substring(j,1) == "0") {
                    grid[j,i] = true;
                }
            }
        }
        
        List<Node> nodes = new List<Node>();
        List<Node> bottomSeek = new List<Node>();
        Node rightSeek = null;
        
        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                if(grid[x,y])
                {
                    Console.Error.WriteLine("Found a node at (" + x +", " + y + ")");
                    Node temp = new Node();
                    temp.x = x;
                    temp.y = y;
                    if(rightSeek != null) 
                    {
                        rightSeek.rightX = x;
                        rightSeek.rightY = y;
                    }
                    rightSeek = temp;
                    nodes.Add(temp);
                    
                    foreach(Node n in bottomSeek)
                    {
                        if(n.x == x && n.y < y) {
                            n.downX = x;
                            n.downY = y;
                            bottomSeek.Remove(n);
                            break;
                        }
                    }
                    bottomSeek.Add(temp);
                }
            }
            rightSeek = null;
        }
        
        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        //Console.WriteLine("0 0 1 0 0 1"); // Three coordinates: a node, its right neighbor, its bottom neighbor
        for(int i = 0; i < nodes.Count; i++)
        {
            Console.WriteLine(nodes[i].x + " " + nodes[i].y + " " + nodes[i].rightX + " " + nodes[i].rightY
            + " " + nodes[i].downX + " " + nodes[i].downY);
        }
    }
}