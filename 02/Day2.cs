namespace AoCSharp._02;

public static class Day2 {
    private static readonly string[] Lines = File.ReadAllLines("02/in.txt");
    private static List<List<string>> _games = new();
    private static Dictionary<string, int> _m = new() { { "blue", 14 }, { "green", 13 }, { "red", 12 } };

    static Day2() {
        foreach (string l in Lines) {
            string[] cl = l.Split(": ");
            List<string> set = cl[1].Split("; ").ToList();
            set.Insert(0, cl[0].Split(" ")[1]);
            _games.Add(set);
        }
    }

    public static void Part1() {
        int total = 0;
        foreach (List<string> g in _games) {
            IEnumerable<string> sets = g.Skip(1);
            bool v = true;
            foreach (string s in sets) {
                string[] cols = s.Split(", ");
                if (cols.Any(col => int.Parse(col.Split(" ")[0]) > _m[col.Split(" ")[1]]))
                    v = false;
            }
            if (v) total += int.Parse(g[0]);
        }
        Console.WriteLine(total);
    }

    public static void Part2() {
        int total = 0;
        foreach (List<string> g in _games) {
            Dictionary<string, int> cnt = new() { {"red", 0}, {"blue", 0}, {"green", 0} };
            IEnumerable<string> sets = g.Skip(1);
            foreach (string s in sets) {
                string[] setSplit = s.Split(", ");
                foreach (string cb in setSplit) {
                    string[] contents = cb.Split(" ");
                    if (int.Parse(contents[0]) > cnt[contents[1]])
                        cnt[contents[1]] = int.Parse(contents[0]);
                }
            }
            total += cnt["red"] * cnt["blue"] * cnt["green"];
        }
        Console.WriteLine(total);
    }
}