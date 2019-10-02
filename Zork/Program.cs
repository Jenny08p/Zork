using System;
using System.Collections.Generic; //hashset uses
using System.IO;
using System.Linq;
using Newtonsoft.Json; 

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
        private static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Zork!");

            Location = IndexOf(Rooms, "West of House");
            Assert.IsTrue(Location != (-1, -1));

            string roomsFileName = args.Length > 0 ? args[0] : "Rooms.json";
            InitializeRooms(roomsFileName);

            Room previousRoom = null;

            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom.ToString());
                if (previousRoom != CurrentRoom)
                {
                    Console.WriteLine(CurrentRoom.Description);
                    previousRoom = CurrentRoom;
                }

                Console.Write("> ");
                command = ToCommand(Console.ReadLine().Trim());


                switch (command)
                {
                    case Commands.QUIT:
                        Console.WriteLine("Thank you for playing!");
                        break;

                    case Commands.LOOK:
                        Console.WriteLine(CurrentRoom.Description);
                        break;
                    case Commands.NORTH:
                    case Commands.SOUTH:
                    case Commands.EAST:
                    case Commands.WEST:
                        if (Move(command) == false)
                        {
                            Console.WriteLine("The way us shut!");
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
            Assert.IsTrue(Directions.Contains(command), "Invalid direction.");

            bool isValidMove = true;
            switch (command)
            {
                case Commands.SOUTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.NORTH when Location.Row < Rooms.GetLength(0) - 1:
                    Location.Row++;
                    break;

                case Commands.EAST when Location.Column < Rooms.GetLength(1) - 1:
                    Location.Column++;
                    break;

                case Commands.WEST when Location.Column > 0:
                    Location.Column--;
                    break;

                default:
                    isValidMove = false;
                    break;
            }

            return isValidMove;
        }

        private static bool IsDirection(Commands command) => Directions.Contains(command);

        private static readonly HashSet<Commands> Directions = new HashSet<Commands>()
        {
           Commands.NORTH,
           Commands.EAST,
           Commands.SOUTH,
           Commands.WEST
         };

        private static void InitializeRooms(string roomsFilename) =>
            Rooms = JsonConvert.DeserializeObject<Room[,]>(File.ReadAllText(roomsFilename));
        /*
        {
            Rooms = JsonConvert.DeserializeObject<Room[]>(File.ReadAllText(roomsFilename));

            foreach (Room room in Rooms)
            {
                RoomMap[room.Name].Description = room.Description;
            }

            string[] lines = File.ReadAllLines(roomsFilename);
            foreach (string line in lines)
            {
                const string fileDelimiter = "##";
                const int expectedFileCount = 2;

                string[] fields = line.Split(fileDelimiter);
                if (fields.Length != expectedFileCount)
                {
                    throw new InvalidDataException("Invalid record.");
                }
                string name = fields[(int)Fields.Name];
                string description = fields[(int)Fields.Description];

                RoomMap[name].Description = description; 
            }
        }
        */

        private static Room[,] Rooms =
        {
            {new Room("Rocky Trail"),  new Room("South of House"),   new Room("Canyon View") },
            {new Room("Forest"),       new Room("West of House"),    new Room("Behind house") },
            {new Room("Dense Woods"),  new Room ("North of House"),  new Room("Clearing") }
        };

        private static (int Row, int Column) Location;

        private static (int Row, int Colum) IndexOf(Room[,] values, string valueToFind)
        {
            for (int row = 0; row < values.GetLength(0); row++)
            {
                for (int column = 0; column < values.GetLength(1); column++)
                {
                    if (values[row, column].Name == valueToFind)
                    {
                        return (row, column);
                    }
                }
            }
            return (-1, -1);
        }

        private enum Fields
        {
            Name = 0,
            Description = 1,
        }

        private enum CommandLineArguments
        {
            RoomsFilename = 0,
            UseLinq
        }
    }
}



