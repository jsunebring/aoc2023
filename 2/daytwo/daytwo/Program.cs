// See https://aka.ms/new-console-template for more information


using daytwo;
using System.Text;

var input = File.ReadAllLines("input.txt", Encoding.UTF8);

var partOne = new PartOne();
partOne.Run(input);

var partTwo = new PartTwo();
partTwo.Run(input);