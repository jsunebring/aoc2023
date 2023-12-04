// See https://aka.ms/new-console-template for more information

using dayThree;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var partOne = new PartOne();
partOne.DoStuff(input);

var partTwo = new PartTwo();
partTwo.DoStuff(input);

