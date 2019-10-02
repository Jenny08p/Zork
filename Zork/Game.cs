using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Zork
{
    public class Game
    {
        public World World { get; }
    }

    public static Game Load(string filename)
    {
        Game game = JsonConvert.DeserializeObject<Game>(File.ReadAllText(filename));
        return game;
    }
}
