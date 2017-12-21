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
enum Direction {SOUTH, EAST, NORTH, WEST, ERROR};

enum Space {empty, unbreakable, breakable, start, end, changeSouth, changeEast, changeNorth, changeWest, beer, inverter, teleporter}

class Map
{
    Space[,] spaces;
    public int width;
    public int height;
    
    public Map(int W, int H)
    {
        width = W;
        height = H;
        spaces = null;
    }
    
    public void SetSpace(int x, int y, Space newSpace)
    {
        spaces[x,y] = newSpace;
    }
    
    public Space GetSpace(int x, int y)
    {
        return spaces[x,y];
    }
    
    public void SetAllSpaces(Space [,] newSpaces)
    {
        spaces = newSpaces;
    }
}

class Bender
{
    public int x,y;
    bool inverted;
    bool breaker;
    Direction heading;
    
    Map map;
    
    public Bender(int x, int y, Map map)
    {
        this.x = x;
        this.y = y;
        inverted = false;
        breaker = false;
        heading = Direction.SOUTH;
        this.map = map;
    }
    
    int newX {
        get { 
            if(heading == Direction.EAST)
                return x+1;
            else if(heading == Direction.WEST)
                return x-1;
            else
                return x;
        }
    }
    
    int newY {
        get {
            if(heading == Direction.NORTH)
                return y-1;
            else if(heading == Direction.SOUTH)
                return y+1;
            else
                return y;
        }
    }
    
    
    public Direction Move()
    {
        while(!CanMove(newX,newY))
        {
            NextHeading();
        }
        
        // Move to the new position, then interact with anything that might be there
        x = newX;
        y = newY;
        Direction temp = heading;
        Console.Error.WriteLine("Moving " + temp + " to (" +x+", "+y+")");
        InteractSpace();
        return temp;
    }
    
    public void NextHeading()
    {
        if(!inverted)
        {
            heading = Direction.SOUTH;
            while(!CanMove(newX, newY)) 
            {
                heading++;
                if(heading == Direction.ERROR)
                {
                    heading = Direction.SOUTH;
                }
            }
        }
        else
        {
            heading = Direction.WEST;
            while(!CanMove(newX, newY))
            {
                heading--;
                if(heading == Direction.ERROR)
                {
                    heading = Direction.WEST;
                }
            }
        }
    }
    
    bool CanMove(int X, int Y)
    {
        bool allowed = true;
        Space s = map.GetSpace(X,Y);
        // always deny access to unbreakable obstacle spaces
        if(s == Space.unbreakable)
            allowed = false;
        // deny access to breakable if not in breaker mode; break obstacle otherwise
        else if(s == Space.breakable) 
        {
            if(!breaker)
                allowed = false;
            else
            {
                Break(X,Y);
            }
        }
        
        return allowed;
    }
    
    public bool OnExit() 
    {
        if(map.GetSpace(x,y) == Space.end)
            return true;
        else
            return false;
    }
    
    void InteractSpace()
    {
        Space s = map.GetSpace(x,y);
        if(s == Space.changeSouth)
            heading = Direction.SOUTH;
        else if(s == Space.changeEast)
            heading = Direction.EAST;
        else if(s == Space.changeNorth)
            heading = Direction.NORTH;
        else if(s == Space.changeWest)
            heading = Direction.WEST;
        else if(s == Space.beer)
            breaker = !breaker;
        else if(s == Space.inverter)
            inverted = !inverted;
        else if(s == Space.teleporter)
            Teleport(x,y);
    }
    
    void Break(int X, int Y)
    {
        // if this got called wrongly, exit with an error
        if(map.GetSpace(X,Y) != Space.breakable)
        {
            Console.Error.WriteLine("Attempted to break non-breakable space");
            return;
        }
        // remove the obstacle
        map.SetSpace(X,Y, Space.empty);
    }
    
    void Teleport(int X, int Y)
    {
        Console.Error.Write("Teleporting! (" + X + ", " + Y + ") to ");
        for(int i = 0; i < map.width; i++)
        {
            for(int j = 0; j < map.height; j++)
            {
                if(map.GetSpace(i,j) == Space.teleporter && !(i == X && j == Y)) 
                {
                    x = i;
                    y = j;
                }
            }
        }
        Console.Error.WriteLine("(" + x + ", " + y + ")");
    }
    
}

class Solution
{
    static Space[,] LoadMap(int lines, int cols, out int startX, out int startY)
    {
        Space[,] map = new Space[cols,lines];
        startX = -1;
        startY = -1;
        
        for (int i = 0; i < lines; i++)
        {
            string row = Console.ReadLine();
            Console.Error.WriteLine(row);
            for(int j = 0; j < cols; j++)
            {
                string s = row.Substring(j,1);
                Space loc = Space.empty;
                if(s == "#")
                    loc = Space.unbreakable;
                else if(s == "X")
                    loc = Space.breakable;
                else if(s == "@") {
                    loc = Space.start;
                    startX = j;
                    startY = i;
                }
                else if(s == "$")
                    loc = Space.end;
                else if(s == "S")
                    loc = Space.changeSouth;
                else if(s == "E")
                    loc = Space.changeEast;
                else if(s == "N")
                    loc = Space.changeNorth;
                else if(s == "W")
                    loc = Space.changeWest;
                else if(s == "B")
                    loc = Space.beer;
                else if(s == "I")
                    loc = Space.inverter;
                else if(s == "T")
                    loc = Space.teleporter;
                else if(s == " ")
                    loc = Space.empty;
                else
                    Console.Error.WriteLine("Unknown space type found!");
                    
                map[j,i] = loc;
            }
        }
        return map;
    }
    
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int L = int.Parse(inputs[0]);
        int C = int.Parse(inputs[1]);
        
        Queue<Direction> moveList = new Queue<Direction>();
        
        int x, y;
        Map map = new Map(C,L);
        map.SetAllSpaces(LoadMap(L,C, out x, out y));
        
        Bender bender = new Bender(x,y, map);

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        while(!bender.OnExit())
        {
            Direction d = bender.Move();
            //Console.Error.WriteLine(d);
            moveList.Enqueue(d);
            if(moveList.Count > 10000)
            {
                Console.Error.WriteLine("Moves exceed 10,000.  Calling it a loop");
                Console.WriteLine("LOOP");
                return;
            }
        }
        
        Console.Error.WriteLine("Beginning move report");
        while(moveList.Count != 0)
        {
            string s = moveList.Dequeue().ToString();
            Console.WriteLine(s);
        }
        //Console.WriteLine("SOUTH");
        //Console.WriteLine("SOUTH");
        //Console.WriteLine("SOUTH");
    }
}