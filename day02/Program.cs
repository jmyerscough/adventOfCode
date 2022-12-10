
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
foreach(var line in lines.Split("\n")) {
    var players = line.Split(" ");
    var computer = moves[players[0]];
    var me =  moves[players[1]];

    if (computer == me) {
        myScore += ((int)me) + ((int)GameResult.Draw);
    }
    else if (computer == Move.Rock && me == Move.Paper) {
        myScore += ((int)GameResult.Win) + ((int)me);
    }
    else if (computer == Move.Scissors && me == Move.Rock) {
        myScore += ((int)GameResult.Win) + ((int)me);
    }
    else if (computer == Move.Paper && me == Move.Scissors) {
        myScore += ((int)GameResult.Win) + ((int)me);
    }
    else {
        myScore += ((int)me);
    }
}

Console.WriteLine(myScore);