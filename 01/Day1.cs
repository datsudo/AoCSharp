using System.Text.RegularExpressions;

namespace AoCSharp._01;

public static class Day1 {
    public static void Part1() {
        string[] lines = File.ReadAllLines("01/in.txt");
        int total = 0;
        foreach (string l in lines) {
            string[] nums = Regex.Matches(l, @"\d")
                // ReSharper disable once RedundantEnumerableCastCall
                .OfType<Match>()
                .Select(n => n.Value)
                .ToArray();
            string fl = nums.Length > 1 ? nums[0]+nums[^1] : nums[0]+nums[0];
            total += int.Parse(fl);
        }
        Console.WriteLine(total);
    }
}