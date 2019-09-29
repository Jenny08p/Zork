using System;
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
        private static Room CurrentRoom
        {
            get
            {
                return Rooms[Location.Row, Location.Column];
            }
        }

        static void Main(string[] args)
        {
            _ = InitializeRoomDescription();

            Console.WriteLine("Welcome to Zork!");

            Location = IndexOf(Rooms, "West of House");
            Assert.IsTrue(Location != (-1, -1));


            Commands command = Commands.UNKNOWN;
            while (command != Commands.QUIT)
            {
                Console.WriteLine(CurrentRoom.ToString() + Environment.NewLine + CurrentRoom.Description); 
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
                case Commands.NORTH when Location.Row > 0:
                    Location.Row--;
                    break;

                case Commands.SOUTH when Location.Row < Rooms.GetLength(0) - 1:
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

        private static Dictionary<string, Room> InitializeRoomDescription()
        {
            var roomMap = new Dictionary<string, Room>();
            foreach (Room room in Rooms)
            {
                roomMap[room.Name] = room;
            }

            roomMap["Rocky Trail"].Description = "You are on a rock-strewn trail.";
            roomMap["South of House"].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred.";
            roomMap["Canyon View"].Description = "You are at the top of the Great Canyon on its south wall.";
            roomMap["Forest"].Description = "This is a forest, with trees in all directions around you.";
            roomMap["West of House"].Description = "This is an open field west of a white house, with a borded front door";
            roomMap["Behind house"].Description = "You are behind the white house. In one corner of the house, there is a small window which is slightly ajar.";
            roomMap["Dense Woods"].Description = "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight.";
            roomMap["North of House"].Description = "You are facing the north side of a white house. There is no door here and all the windows are barred.";
            roomMap["Clearing"].Description = "You are in a clearing with a forest surrounding you on the west and south.";

            return roomMap; 

        }

        
        
        /*Rooms[0, 0].Description = "You are on a rock-strewn trail."; // Rocky Trail
            Rooms[0, 1].Description = "You are facing the south side of a white house. There is no door here, and all the windows are barred."; // South of House
            Rooms[0, 2].Description =  "You are at the top of the Great Canyon on its south wall." ;       // Canyon View

            Rooms[1, 0].Description =  "This is a forest, with trees in all directions around you." ;       // Forest
            Rooms[1, 1].Description =  "This is an open field west of a white house, with a borded front door" ;       // West of house 
            Rooms[1, 2].Description =  "You are behing the white house. In one corner of the house, there is a small window which is slightly ajar." ;       // Behind House

            Rooms[2, 0].Description =  "This is a dimly lit forest, with large trees all around. To the east, there appears to be sunlight." ;       // Dense Woods
            Rooms[2, 1].Description =  "You are facing the north side of a white house. There is no door here and all the windows are barred." ;       // North of House
            Rooms[2, 1].Description =  "You are in a clearing with a forest surrounding you on the west and south." ;       // Clearing 
         
        } */ 

        private static readonly Room[,] Rooms =
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
    }
}

/*   Room westOfHouse = new Room("West of House");
Console.Write(westOfHouse.Name);

            westOfHouse.Description = "";
            Console.WriteLine(westOfHouse.Description);

            Console.WriteLine("\n\n");
*/



