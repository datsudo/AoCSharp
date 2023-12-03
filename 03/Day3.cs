namespace AoCSharp._03;

public static class Day3 {
    private static readonly List<string> Lines = new(File.ReadAllLines("03/in.txt"));
    private static readonly int[][] Dir = {
        new[]{ 0, -1 }, new[]{ -1, -1 }, new[]{ 1, -1 },
        new[]{ -1, 0 }, new[]{ 1, 0 },
        new[]{ 0, 1 },  new[]{ -1, 1 }, new[]{ 1, 1 }
    };

    static Day3() {
        for (int i = 0; i < Lines.Count; i++) Lines[i] = '.' + Lines[i] + '.';
        string nL = new('.', Lines.Count + 2);
        Lines.Insert(0, nL); Lines.Add(nL);
    }

    private static bool Valid(int rc, int cc) {
        return Dir
            .Where(d => !char.IsDigit(Lines[rc + d[0]][cc + d[1]]))
            .Any(d => Lines[rc + d[0]][cc + d[1]] != '.');
    }

    private static (int, int) IsGearNum(int rc, int cc) {
        foreach (int[] d in Dir) {
            if (char.IsDigit(Lines[rc + d[0]][cc + d[1]])) continue;
            if (Lines[rc + d[0]][cc + d[1]] == '*')
                return (rc + d[0], cc + d[1]);
        }
        return (-1, -1);
    }

    public static void Part1() {
        int total = 0;
        for (int i = 0; i < Lines.Count; i++) {
            int c = 0;
            while (c < Lines[i].Length) {
                string n = "";
                bool v = false;
                while (char.IsDigit(Lines[i][c])) {
                    if (Valid(i, c)) v = true;
                    n += Lines[i][c]; c++;
                }
                if (v) total += int.Parse(n);
                c++;
            }
        }
        Console.WriteLine(total);
    }

    public static void Part2() {
        Dictionary<(int, int), List<int>> gears = new();
        for (int i = 0; i < Lines.Count; i++) {
            int c = 0;
            while (c < Lines[i].Length) {
                string n = "";
                bool v = false;
                (int,  int) gearLoc = new(-1,-1);
                while (char.IsDigit(Lines[i][c])) {
                    if (IsGearNum(i, c).Item1 != -1) {
                        gearLoc = IsGearNum(i, c);
                        v = true;
                    }
                    n += Lines[i][c]; c++;
                }
                if (v) {
                    if (gears.ContainsKey(gearLoc) && gears[gearLoc].Count == 1)
                        gears[gearLoc].Add(int.Parse(n));
                    else gears.Add(gearLoc, new List<int> {int.Parse(n)});
                }
                c++;
            }
        }

        int total = gears
            .Where(gr => gr.Value.Count == 2)
            .Sum(gr => gr.Value[0] * gr.Value[1]);
        Console.WriteLine(total);
    }
}