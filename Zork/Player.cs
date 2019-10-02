using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zork
{
    public class Player
    {
        public World world { get; }

        [JsonIgnore]
        public Room Location { get; private set; }

        [JsonIgnore]

        public string LocationName
        {
            get
            {
                return Location?.Name;
            }
            set
            {
                Location = World?.RoomsByName.GetValueOrDefault(value);
            }

        }


            public bool Move(Directions direction)
        {
            bool isValidMove = Location.Neighbbors.TryGetValure(direction, out Room destination);
            if (isValidMove)
            {
                Location = destination;
            }

            return isValidMove;
            }
        }
    }
