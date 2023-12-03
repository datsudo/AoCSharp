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
        bool res = false;
        foreach (int[] d in Dir) {
            if (char.IsDigit(Lines[rc + d[0]][cc + d[1]])) continue;
            if (Lines[rc + d[0]][cc + d[1]] != '.')
                res = true;
        }
        return res;
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
                if (n != "" && v) total += int.Parse(n);
                c++;
            }
        }

        Console.WriteLine(total);
    }
}