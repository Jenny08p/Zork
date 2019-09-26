using System;
using System.Collections.Generic; //hashset uses
using System.Diagnostics;


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
        private static string CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        { 
            Console.WriteLine("Welcome to Zork!");

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom);
                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());

                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine("This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.");
                        break;

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The wat us shut!");
                        }
                        
                        break;

                    default:
                        Console.WriteLine("Unknown command.");
                        break;

                }
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
            Assert.IsTrue(IsDirection(command), "Invalid direction.");

            bool isValidMove = true; 
            switch (command)
            {
                case Commands.NORTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.SOUTH when Location.Row > 0:
                    Location.Row++;
                    break;

                case Commands.EAST when Location.Row > 0:
                    Location.Column++;
                    break;

                case Commands.WEST when Location.Row > 0:
                    Location.Column--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }

        private static int LocationColumn;

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static readonly HashSet<Commands> Directions = new HashSet<Commands>()
        {
           Commands.NORTH,
           Commands.EAST,
           Commands.SOUTH,
           Commands.WEST
         };

        private static readonly string[,] Rooms = 
        {
            { "Rocky Trail", "South of House", "Canyon View" },
                              
            { "Forest", "West of House", "Behind house" }, 
            
            { "Dense Woods", "North of House", "Clearing" }
        };

        private static (int Row, int Column) Location = (1, 1);
    }
    //private bool IndexOf(string[,] values, string valureToFind)
    // {
    //  bool found = false;
    //   for (int row = 0; LocationColumn < values.GetLength(1); LocationColumn++)

    // {
    //   if (valueToFind == values[row, column])
    //  {
    //    found = true;
    //     break;
    // }
    //  }
    //  }
}
