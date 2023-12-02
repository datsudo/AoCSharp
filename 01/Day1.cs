using System.Text.RegularExpressions;

namespace AoCSharp._01;

public static class Day1 {
    private static readonly string[] Lines = File.ReadAllLines("01/in.txt");

    public static void Part1() {
        // "LINQ" expression
        Console.WriteLine((from l in Lines
            select Regex.Matches(l, @"\d")
                .Select(n => n.Value)
                .ToArray()
            into nums
            select nums.Length > 1 ? int.Parse(nums[0] + nums[^1]) : int.Parse(nums[0]) * 11
            into firstLastNum
            select firstLastNum).Sum());
    }
}