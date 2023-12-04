using System.Text.RegularExpressions;

namespace AoCSharp._04;

public static class Day4 {
    private static readonly List<string> Lines = new(File.ReadAllLines("04/in.txt"));

    private static List<int> GetNums(string s) {
        return Regex.Matches(s, @"\d+").Select(n => int.Parse(n.Value)).ToList();
    }

    public static void Part1() {
        int points = (from ln in Lines
            select ln.Split(": ")[1].Split(" | ").ToList()
            into cards
            select GetNums(cards[0]).Intersect(GetNums(cards[1])).Count()
            into winNums
            select (int)Math.Pow(2, winNums - 1)).Sum();

        Console.WriteLine(points);
    }

    public static void Part2() {
        Dictionary<int, int> cpLog = new();
        for (int i = 0; i < Lines.Count; i++) {
            cpLog.TryAdd(i, 1);
            List<string> cards = Lines[i].Split(": ")[1].Split(" | ").ToList();
            int winNums = GetNums(cards[0]).Intersect(GetNums(cards[1])).Count();
            for (int j = 0; j < winNums; j++) {
                cpLog.TryAdd(i+j+1, 1);
                cpLog[i+j+1] += cpLog[i];
            }
        }
        Console.WriteLine(cpLog.Sum(c => c.Value));
    }
}