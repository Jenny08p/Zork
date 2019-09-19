﻿using System;
using System.Collections.Generic; //hashset uses

namespace Zork
{
    enum Commands
    {
        QUIT,
        LOOK,
        NORTH,
        SOUTH,
        EAST,
        WEST,
        UNKNOWN
    }
    class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(Rooms[PlayerPosition]);
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                string outputString;
                switch (command)
                {
                    case Commands.QUIT:
                        outputString = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        outputString = "This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        bool movedSucessfully = Move(command);
                        if (movedSucessfully)
                        {
                            outputString = $"You moved {command}.";

                        }
                        else
                        {
                            outputString = $"The way is shut!";
                        }
                        break;

                    default:
                        outputString = "Unknown Command";
                        break;

                }

                Console.WriteLine(outputString);
            }

        }

        private static Commands ToCommand(string commandString)
        {
            if (Enum.TryParse<Commands>(commandString, ignoreCase: true, out Commands result))
            {
                return result;
            }
            else
            {
                return Commands.UNKNOWN;
            }
        }

        private static bool Move(Commands command)
        {
            if (Directions.Contains(command) == false)
            {
                throw new ArgumentException();
            }

            bool movedSuccessfully;

            switch (command)
            {
                case Commands.NORTH:
                case Commands.SOUTH:
                    movedSuccessfully = false;
                    break;

                case Commands.EAST when PlayerPosition < Rooms.Length - 1:
                    PlayerPosition++;
                    movedSuccessfully = true;             
                    break;

                case Commands.WEST when PlayerPosition > 0:
                    PlayerPosition--;
                    movedSuccessfully = true;
                    break;

                default:
                    movedSuccessfully = false;
                    break;
            }


            return movedSuccessfully;
        }

        private static readonly HashSet<Commands> Directions = new HashSet<Commands>()
        {
           Commands.NORTH,
           Commands.EAST,
           Commands.SOUTH,
           Commands.WEST
         };

        private static readonly string[] Rooms = { "Forest", "West of House", "Behind house", "Clearing", "Canyon View" };
        private static int PlayerPosition = 1; 
    }
}
