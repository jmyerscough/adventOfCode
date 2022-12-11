var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);

var containsCount = 0;
var overlapCount = 0;

foreach(var line in lines.Split("\n")) {
    var range1 = line.Split(",")[0];
    var range2 = line.Split(",")[1];

    var s1 = buildRange(range1);
    var s2 = buildRange(range2);

    if (part2(range1, range2))
        ++overlapCount;

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
Console.WriteLine($"overlapCount = {overlapCount}");

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

// dirty, don't like my implementation.
bool part2(string range1, string range2) {
    var r1 = new List<int>();
    var r2 = new List<int>();

    var start1 = int.Parse(range1.Split("-")[0]);
    var end1 = int.Parse(range1.Split("-")[1]);
    var start2 = int.Parse(range2.Split("-")[0]);
    var end2 = int.Parse(range2.Split("-")[1]);

    for (int i=start1; i <= end1; i++)
        r1.Add(i);

    for (int i=start2; i <= end2; i++)
        r2.Add(i);

    if (r1.Count >= r2.Count) {
        foreach (var n in r2)
            if (r1.Contains(n))
                return true;
    } else {
        foreach (var n in r1)
            if (r2.Contains(n))
                return true;
    }
    return false;
}
