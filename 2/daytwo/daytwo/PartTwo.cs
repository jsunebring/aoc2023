using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daytwo
{
    public class PartTwo
    {
        public void Run(string[] input)
        {
            var games = new List<Game>();

            foreach (var line in input)
                games.Add(new Game(line));

            var total = 0;
            foreach (var game in games)
            {
                var powers = new List<int>();

                var colorGroups = game.Sets.GroupBy(x => x.Item1);
                foreach (var colorGroup in colorGroups)
                {
                    powers.Add(colorGroup.Max(x => x.Item2));
                }
                var multiply = powers.Aggregate((x, y) => x * y);
                
                total += multiply;
            }
            
            Console.WriteLine($"Part two: {total}");
        }
    }
}
