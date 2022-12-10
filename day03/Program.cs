var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);
var priorities = 0;
const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

foreach(var line in lines.Split("\n")) {
    priorities += part1(line);
}
Console.WriteLine($"Sum of priorities: {priorities}");

part2(lines.Split("\n"));

int part1(string s) {
    var s1 = s.Substring(0, s.Length / 2);
    var s2 = s.Substring(s.Length / 2);

    foreach (var c in s1) {
        if (s2.Contains(c)) {
            return letters.IndexOf(c) + 1;
        }
    }
    return 0;
}

void part2(string [] lines) {
    var r = 0;
    for (int i = 0; i <= lines.Length - 3; i+=3) {
        foreach (var c in lines[i]) {
            if (lines[i+1].Contains(c) && lines[i+2].Contains(c)) {
                r += letters.IndexOf(c) + 1;
                break;
            }
        }
    }
    Console.WriteLine($"Part 2 priority: {r}");
}
