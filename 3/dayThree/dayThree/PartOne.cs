using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dayThree
{
    public class PartOne
    {
        public void DoStuff(string[] input)
        {
            var goodCoords = new List<Tuple<int, int>>();
            var numbers = new List<Number>();

            var partRegex = new Regex(@"([^0-9\.])", RegexOptions.IgnoreCase);
            var numberRegex = new Regex(@"([0-9]+)", RegexOptions.IgnoreCase);

            for (int i = 0; i < input.Length; i++)
            {
                var partGroups = partRegex.Matches(input[i].Trim());
                foreach (Match match in partGroups)
                    goodCoords.Add(new Tuple<int, int>(match.Index, i));

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

            var total = 0;
            foreach (var number in numbers)
            {
                var adjacent = number.GetAdjacent();
                var weGood = false;

                foreach (var coord in adjacent)
                {
                    if (goodCoords.Contains(coord))
                        weGood = true;
                }

                if (weGood)
                    total += number.Value;

            }

            Console.WriteLine(total);
        }
    }
}
