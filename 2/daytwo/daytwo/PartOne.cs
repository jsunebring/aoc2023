using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daytwo
{
    public class PartOne
    {
        public void Run(string[] input)
        {
            var games = new List<Game>();

            var allowed = new Dictionary<string, int> { { "red", 12 }, { "green", 13 }, { "blue", 14 } };

            foreach (var line in input)
                games.Add(new Game(line));

            var notAllowedIds = games
                .Where(game => game.Sets.Any(set => set.Item2 > allowed[set.Item1]))
                .Select(game => game.Id)
                .ToList();

            var okGames = games.Where(x => !notAllowedIds.Contains(x.Id)).ToList();
            var sum = okGames.Sum(x => x.Id);
            Console.WriteLine($"Part one: {sum}");
        }
    }
}
