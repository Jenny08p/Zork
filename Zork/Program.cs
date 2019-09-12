using System;

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

            string inputString = Console.ReadLine();
            inputString = inputString.ToUpper();
            Commands command = ToCommand(inputString.Trim().ToUpper());
            Console.WriteLine(command);
            if (inputString == "QUIT")
            {
                Console.WriteLine("Thank you for playing.");
            }
            else if (inputString == "LOOK")
            {
                Console.WriteLine("This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
            }
            else
            {
                Console.WriteLine("Unrecognized command.");
            }

        }

        private static Commands ToCommand(string commandString)
        {
            Commands command;

            switch (commandString)
            {
                case "QUIT":
                    command = Commands.QUIT;
                    break;

                case "LOOK":
                    command = Commands.LOOK;
                    break;

                case "NORTH":
                    command = Commands.NORTH;
                    break;

                case "SOUTH":
                    command = Commands.SOUTH;
                    break;

                case "EAST":
                    command = Commands.EAST;
                    break;

                case "WEST":
                    command = Commands.WEST;
                    break;

                default:
                    command = Commands.UNKNOWN;
                    break;
            };

            return command;

        }

     }
}
