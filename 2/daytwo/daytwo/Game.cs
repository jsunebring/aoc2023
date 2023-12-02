using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daytwo
{
    public class Game
    {
        public Game()
        {
            
        }
        public Game(string input)
        {
            var split = input.Split(":");
            Id = int.Parse(split[0].Split(' ').Last());
            var sets = split[1].Split(";");
            foreach (var item in sets)
            {
                var properties = item.Split(",");
                foreach (var prop in properties)
                {
                    var propSplit = prop.Trim().Split(' ');
                    Sets.Add(new Tuple<string, int>(propSplit[1], int.Parse(propSplit[0])));
                }
            }
        }
        public int Id { get; set; }
        public List<Tuple<string, int>> Sets { get; set; } = new List<Tuple<string, int>>();
    }

    public class Set
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }
}
