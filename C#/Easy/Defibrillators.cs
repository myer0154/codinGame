using System;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    struct defibInfo 
    {
        public int num;
        public string name;
        public string address;
        public string phone;
        public double longitude;
        public double latitude;
        public string longString;
        public string latString;
    }
    
    static void Main(string[] args)
    {
        string LON = Console.ReadLine();
        string LAT = Console.ReadLine();
        int N = int.Parse(Console.ReadLine());
        
        string temp = "";
        for(int j = 0; j < LON.Length; j++)
        {
            string t2 = LON.Substring(j,1);
            if(t2 == ",")
                temp += ".";
            else
                temp += t2;
        }
        double lon = double.Parse(temp);
        
        temp = "";
        for(int j = 0; j < LAT.Length; j++)
        {
            string t2 = LAT.Substring(j,1);
            if(t2 == ",")
                temp += ".";
            else
                temp += t2;
        }
        double lat = double.Parse(temp);
        Console.Error.WriteLine("User loc: (" + lon + ", " + lat);
        
        var defibs = new defibInfo[N];
        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            string [] info = DEFIB.Split(';');
            Console.Error.WriteLine(DEFIB);
            if(info.Length < 6) {
                Console.Error.WriteLine("Entry missing some info");
            }
            else
            {
                defibs[i].num = int.Parse(info[0]);
                defibs[i].name = info[1];
                defibs[i].address = info[2];
                defibs[i].phone = info[3];
                defibs[i].longString = info[4];
                defibs[i].latString = info[5];
                
                temp = "";
                for(int j = 0; j < defibs[i].longString.Length; j++)
                {
                    string t2 = defibs[i].longString.Substring(j,1);
                    if(t2 == ",")
                        temp += ".";
                    else
                        temp += t2;
                }
                //Console.Error.WriteLine("longstring: " + defibs[i].longString + " -> " + temp);
                defibs[i].longitude = double.Parse(temp);
                
                temp = "";
                for(int j = 0; j < defibs[i].latString.Length; j++)
                {
                    string t2 = defibs[i].latString.Substring(j,1);
                    if(t2 == ",")
                        temp += ".";
                    else
                        temp += t2;
                }
                defibs[i].latitude = double.Parse(temp);
                //Console.Error.WriteLine(defibs[i].longitude +", " + defibs[i].latitude);
            }
        }
        
        string bestDefibName = "";
        double bestDist = double.MaxValue;
        for (int a = 0; a < N; a++)
        {
                double x = (lon - defibs[a].longitude)*Math.Cos((defibs[a].latitude + lat)/2);
                double y = lat - defibs[a].latitude;
                double dist = Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2))*6371;
                
                if(dist < bestDist) 
                {
                    bestDist = dist;
                    bestDefibName = defibs[a].name;
                }
            
        }

        // Write an action using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(bestDefibName);
    }
}