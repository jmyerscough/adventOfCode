using System.Text.RegularExpressions;

var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);
var offset = 0;

manipulateStacks(parseStacks(lines.Split("\n"), out offset), lines.Split("\n"), offset + 1);

List<Stack<char>> parseStacks(string [] input, out int offset) {
    var i = 0;

    // read the list of stacks
    while (input[i].Length > 1) {
        ++i;
    }
    var indices = input[i-1];
    offset = i;

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

void manipulateStacks(List<Stack<char>> sl, string [] instructions, int offset) {
    for (var i=0; i < instructions.Length - offset; i++) {
        var rx = new Regex(@"\d+", RegexOptions.Compiled);
        var matches = rx.Matches(instructions[offset + i]);

        if (matches.Count == 3) {
            var amount = int.Parse(matches[0].ToString());
            var from = int.Parse(matches[1].ToString());
            var to = int.Parse(matches[2].ToString());

            for (var j=0; j < amount; j++) {
                sl[to-1].Push(sl[from-1].Pop());
            }
        }
    }
    foreach (var stack in sl) {
        if (stack.Count > 0)
            Console.Write(stack.Pop());
    }
    Console.WriteLine();
}
