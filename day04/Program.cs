
var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);

var containsCount = 0;

foreach(var line in lines.Split("\n")) {
    var range1 = line.Split(",")[0];
    var range2 = line.Split(",")[1];

    var s1 = buildRange(range1);
    var s2 = buildRange(range2);

    if (s1.Length == s2.Length) {
        if (s1 == s2) ++containsCount;
    } else {
        var start1 = int.Parse(range1.Split("-")[0]);
        var end1 = int.Parse(range1.Split("-")[1]);
        var start2 = int.Parse(range2.Split("-")[0]);
        var end2 = int.Parse(range2.Split("-")[1]);

        if (s1.Length < s2.Length) {
            if (start1 >= start2 && end1 <= end2) ++containsCount;
        }
        else {
            if (start2 >= start1 && end2 <= end1) ++containsCount;
        }
    }
}
Console.WriteLine($"containsCount = {containsCount}");

string buildRange(string s) {
    var start = int.Parse(s.Split("-")[0]);
    var end = int.Parse(s.Split("-")[1]);
    var result = "";

    for (int i=0; i <= end; i++)
    {
        if (i >= start && i <= end) {
            result += i;
        }
    }
    return result;
}
