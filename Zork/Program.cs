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


           // string inputString = Console.ReadLine(); 
            //inputString = inputString.ToUpper();
            //Commands command = ToCommand(inputString.Trim().ToUpper());
           // Console.WriteLine(command);
           
            //{
             //   Console.WriteLine("Thank you for playing.");
            //}
            //else if (inputString == "LOOK")
            //{
              //  Console.WriteLine("This is an open field west of a white house, with a boarded front door. \nA rubber mat saying 'Welcome to Zork!' lies by the door.");
           // }
            //else
            //{
             //   Console.WriteLine("Unrecognized command.");
            //}

        }

        private static Commands ToCommand(string commandString)
        {
           if (Enum.TryParse<Commands>(commandString, ignoreCase: true, out Commands result))
            {
                return command;
            }
           else
            {
                return Commands.UNKNOWN;
            }
        }

     }
}
