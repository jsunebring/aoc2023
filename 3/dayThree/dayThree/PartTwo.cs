using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dayThree
{
    public class PartTwo
    {
        public void DoStuff(string[] input)
        {
            var starCoords = new List<Tuple<int, int>>();
            var numbers = new List<Number>();

            var starRegex = new Regex(@"\*", RegexOptions.IgnoreCase);
            var numberRegex = new Regex(@"([0-9]+)", RegexOptions.IgnoreCase);

            for (int i = 0; i < input.Length; i++)
            {
                var starGroups = starRegex.Matches(input[i].Trim());
                foreach (Match match in starGroups)
                    starCoords.Add(new Tuple<int, int>(match.Index, i));

                var numberGroups = numberRegex.Matches(input[i]);
                foreach (Match numberGroup in numberGroups)
                {
                    var number = new Number();
                    number.Value = int.Parse(numberGroup.Value);
                    number.X = new List<int>();
                    for (int j = 0; j < numberGroup.Length; j++)
                        number.X.Add(numberGroup.Index + j);

                    number.Y = i;
                    numbers.Add(number);
                }
            }

            var allNumberCoords = numbers.SelectMany(x => x.GetAdjacent().Select(y => new Tuple<int, Tuple<int, int>>(x.Value, y))).ToList();
            var total = 0;
            foreach (var star in starCoords)
            {
                var hits = allNumberCoords.Where(y => y.Item2.Item1 == star.Item1 && y.Item2.Item2 == star.Item2);
                if (hits.Count() == 2)
                {
                    total += hits.First().Item1 * hits.Last().Item1;
                }
            }

            Console.WriteLine(total);
        }
    }
}
