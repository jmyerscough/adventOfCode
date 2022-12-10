
var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);
var priorities = 0;
const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

foreach(var line in lines.Split("\n")) {
    var s1 = line.Substring(0, line.Length / 2);
    var s2 = line.Substring(line.Length / 2);

    foreach (var c in s1) {
        if (s2.Contains(c)) {
            priorities += letters.IndexOf(c) + 1;
            break;
        }
    }
}
Console.WriteLine($"Sum of priorities: {priorities}");
