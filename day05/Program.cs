var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);

parseStacks(lines.Split("\n"));


List<Stack<char>> parseStacks(string [] input) {
    var i = 0;

    // read the list of stacks
    while (input[i].Length > 1) {
        ++i;
    }
    var indices = input[i-1];

    // get the number of stacks
    var stackCount = int.Parse(indices.Trim()[indices.Trim().Length -1].ToString());
    var stacks = new List<Stack<char>>(stackCount);

    for (var j=0; j < stackCount; j++) stacks.Add(new Stack<char>());
 
    // read the stacks
    for (var j=i-2; j >= 0; j--) {
        for (var k = 1; k <= stackCount; k++) {
            var idx = indices.IndexOf((k.ToString()));
            if (Char.IsLetter(input[j][idx]))
                stacks[k-1].Push((input[j][idx]));
        }
    }
    return stacks;
}