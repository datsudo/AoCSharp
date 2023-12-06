using System.Text.RegularExpressions;

namespace AoCSharp._06;

public static class Day6 {
    private static List<string> Lines = new(File.ReadAllLines("06/in.txt"));
    private static readonly List<int>
        Time = Regex.Matches(Lines[0], @"\d+").Select(t => int.Parse(t.Value)).ToList(),
        Distance = Regex.Matches(Lines[1], @"\d+").Select(d => int.Parse(d.Value)).ToList();

    public static void Part1() {
        int res = 1;
        for (int i = 0; i < Time.Count; i++) {
            int ht = 0, nways = 0;
            while (ht <= Time[i]) {if ((Time[i] - ht) * ht > Distance[i]) nways++; ht++;}
            res *= nways;
        }
        Console.WriteLine(res);
    }

    public static void Part2() {
        long nWays = 0, realTime = long.Parse(String.Join("", Time)),
            realDistance = long.Parse(String.Join("", Distance));
        while (ht <= realTime) {if ((realTime - ht) * ht > realDistance) nWays++;}
        Console.WriteLine(nWays);
    }
}
