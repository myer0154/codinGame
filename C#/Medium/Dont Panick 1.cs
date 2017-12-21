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
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int nbFloors = int.Parse(inputs[0]); // number of floors
        int width = int.Parse(inputs[1]); // width of the area
        int nbRounds = int.Parse(inputs[2]); // maximum number of rounds
        int exitFloor = int.Parse(inputs[3]); // floor on which the exit is found
        int exitPos = int.Parse(inputs[4]); // position of the exit on its floor
        int nbTotalClones = int.Parse(inputs[5]); // number of generated clones
        int nbAdditionalElevators = int.Parse(inputs[6]); // ignore (always zero)
        int nbElevators = int.Parse(inputs[7]); // number of elevators
        
        int[] elevPos = new int[nbFloors];
        
        for (int i = 0; i < nbElevators; i++)
        {
            inputs = Console.ReadLine().Split(' ');
            int elevatorFloor = int.Parse(inputs[0]); // floor on which this elevator is found
            int elevatorPos = int.Parse(inputs[1]); // position of the elevator on its floor
            elevPos[elevatorFloor] = elevatorPos;
        }
        
        elevPos[exitFloor] = exitPos;

        // game loop
        while (true)
        {
            bool block = false;
            
            inputs = Console.ReadLine().Split(' ');
            int cloneFloor = int.Parse(inputs[0]); // floor of the leading clone
            int clonePos = int.Parse(inputs[1]); // position of the leading clone on its floor
            string direction = inputs[2]; // direction of the leading clone: LEFT or RIGHT

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            if(cloneFloor == -1) {
                Console.WriteLine("WAIT");
                Console.Error.WriteLine("No clone present, waiting");
            }
            else 
            {
                Console.Error.WriteLine("Lead clone at floor " + cloneFloor + " at " + clonePos + " heading " + direction);
                Console.Error.WriteLine("Elevator on this floor is at " + elevPos[cloneFloor]);
                if(clonePos > elevPos[cloneFloor] && direction == "RIGHT") {
                   Console.Error.WriteLine("Blocking because pos < elevPos and heading left");
                   block = true;
                }
                if ((clonePos < elevPos[cloneFloor]) && direction == "LEFT") {
                    Console.Error.WriteLine("clonePos < elevPos");
                    
                
                    Console.Error.WriteLine("clonePos = " + clonePos);
                    Console.Error.WriteLine("elevPos = " + elevPos[cloneFloor]);
                    Console.Error.WriteLine("direction = " + direction);
                    Console.Error.WriteLine("Blocking because pos < elevPos and heading left");
                    block = true;
                
                }
                    


            
                if(block)
                    Console.WriteLine("BLOCK");
                else
                    Console.WriteLine("WAIT"); // action: WAIT or BLOCK
            }
        }
    }
}