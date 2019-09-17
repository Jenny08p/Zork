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

            Commands command = Commands.UNKNOWN;
            while (command!= Commands.QUIT)
            {
                Console.Write(">");
                command = ToCommand(Console.ReadLine().Trim());

                string response; 
                switch (command)
                {
                    case Commands.QUIT:
                        response = "Thank you for playing!";
                        break;

                    case Commands.LOOK:
                        response = "This is an open field west of a white house, with a boarded front door.A rubber mat saying 'Welcome to Zork!' lies by the door.";
                        break; 

                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                    response = $"You moved {command.ToString().ToLower()}";
                    break;

                    default:
                        response = "Unknown Command";
                        break;
                            
                }
                Console.WriteLine(response);
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

     }
}
