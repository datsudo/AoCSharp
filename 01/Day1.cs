using System.Text.RegularExpressions;

namespace AoCSharp._01;

public static class Day1 {
    private static readonly string[] Lines = File.ReadAllLines("01/in.txt");
    private static readonly Dictionary<string, int> NumDict = new(){
        {"one",    1},
        {"two",    2},
        {"three",  3},
        {"four",   4},
        {"five",   5},
        {"six",    6},
        {"seven",  7},
        {"eight",  8},
        {"nine",   9},
        {"zero",   0},
    };

    public static void Part1() {
        // "LINQ" expression
        Console.WriteLine((from l in Lines
            select Regex.Matches(l, @"\d")
                .Select(n => n.Value)
                .ToArray()
            into nums
            select nums.Length == 0 ? 0
                : nums.Length > 1 ? int.Parse(nums[0] + nums[^1])
                : int.Parse(nums[0]) * 11).Sum());
    }

    public static void Part2() {
        int total = 0;
        foreach (string l in Lines) {
            List<int> fn = new List<int>();
            for (int i = 0; i < l.Length; i++) {
                if (char.IsDigit(l[i])) fn.Add(int.Parse(l[i].ToString()));
                fn.AddRange(from item in NumDict
                    where string.Concat(l.Skip(i)).StartsWith(item.Key)
                    select item.Value);
            }
            total += fn[0] * 10 + fn[^1];
        }
        Console.WriteLine(total);
    }
}