
var filename = "input.txt";
var lines = System.IO.File.ReadAllText(filename);

var moves = new Dictionary<string, Move>() {
    {"A", Move.Rock},
    {"X", Move.Rock},
    {"B", Move.Paper},
    {"Y", Move.Paper},
    {"C", Move.Scissors},
    {"Z", Move.Scissors}
};

var myScore = 0;
var myScorePart2 = 0;
foreach(var line in lines.Split("\n")) {
    myScore += part1(line);
    myScorePart2 += part2(line);
}

Console.WriteLine($"Part 1: {myScore}, Part 2: {myScorePart2}");

int part1(string s) {
    var players = s.Split(" ");
    var computer = moves[players[0]];
    var me =  moves[players[1]];

    if (computer == me) {
        return ((int)me) + ((int)GameResult.Draw);
    }
    else if (computer == Move.Rock && me == Move.Paper) {
        return ((int)GameResult.Win) + ((int)me);
    }
    else if (computer == Move.Scissors && me == Move.Rock) {
        return ((int)GameResult.Win) + ((int)me);
    }
    else if (computer == Move.Paper && me == Move.Scissors) {
        return ((int)GameResult.Win) + ((int)me);
    }
    else {
        return ((int)me);
    }
}

int part2(string s) {
    var players = s.Split(" ");
    var computer = moves[players[0]];
    var me =  moves[players[1]];

    switch (players[1]) {
        case "X": 
            return  computer == Move.Rock ? ((int)Move.Scissors) : computer == Move.Paper ? ((int)Move.Rock) : ((int)Move.Paper);
        case "Y": return ((int)GameResult.Draw) + ((int)computer);
        case "Z": 
            return  computer == Move.Rock ? ((int)Move.Paper) + ((int)GameResult.Win) : computer == Move.Paper ?
                ((int)Move.Scissors) + ((int)GameResult.Win) : ((int)Move.Rock) + ((int)GameResult.Win);
    }
    return 0;
}
