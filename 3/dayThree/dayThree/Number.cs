using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dayThree
{
    public class Number
    {
        public int Value { get; set; }
        public List<int> X { get; set; }
        public int Y { get; set; }

        public List<Tuple<int, int>> GetAdjacent()
        {
            var adjecent = new List<Tuple<int, int>>();
            // In front of and behind on same row
            adjecent.Add(new Tuple<int, int>(X.Min() - 1, Y));
            adjecent.Add(new Tuple<int, int>(X.Max() + 1, Y));

            // Above and below
            adjecent.Add(new Tuple<int, int>(X.Min() - 1, Y - 1));
            adjecent.Add(new Tuple<int, int>(X.Max() + 1, Y - 1));
            adjecent.Add(new Tuple<int, int>(X.Min() - 1, Y + 1));
            adjecent.Add(new Tuple<int, int>(X.Max() + 1, Y + 1));
            foreach (var coordX in X)
            {
                adjecent.Add(new Tuple<int, int>(coordX, Y - 1));
                adjecent.Add(new Tuple<int, int>(coordX, Y + 1));
            }

            return adjecent;
        }

    }
}
