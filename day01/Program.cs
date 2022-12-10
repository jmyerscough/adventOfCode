

var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);
var elves = new List<int>();

var calorieCount = 0;
var maxCount = 0;

foreach(var line in lines.Split("\n")) {
    if(line.ToString().Length > 0) {
        var c = 0;
        if (Int32.TryParse(line.ToString(), out c)) {
            calorieCount += c;
        }
    }
    else
    {
        elves.Add(calorieCount);
        if (calorieCount > maxCount) {
            maxCount = calorieCount;
        }
        calorieCount = 0;
    }
}

elves.Sort();
var top3 = elves[elves.Count() - 1] + elves[elves.Count() - 2] + elves[elves.Count() - 3];


Console.WriteLine($"Max Calorie Count: {maxCount}");
Console.WriteLine($"Top 3: {top3}");