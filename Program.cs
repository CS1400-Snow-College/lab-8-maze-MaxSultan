// Max Sultan, October 30th, Lab 8: Maze

void Main()
{
    Console.Title = "Maze Game";
    Console.Clear();
Console.Write(@"
Welcome to Maze game.
Avoid the #s
Make it the the *
Use Arrow keys to move
Good Luck!
");

    int verticalOffset = 5;
    bool continuePlaying = true;

    string[] mapRows = File.ReadAllLines("./map.txt");
    foreach(string row in mapRows)
        Console.WriteLine(row);

    Dictionary<string, int> mapBounds = new Dictionary<string, int>
    {
        {"left", 0},
        {"right", mapRows[0].Length - 1},
        {"top", verticalOffset},
        {"bottom", mapRows.Length + verticalOffset - 1},
    };

    Console.SetCursorPosition(mapBounds["left"], mapBounds["top"]);

    do {
        ConsoleKey inputKey = Console.ReadKey(true).Key;
        (int leftDelta, int topDelta) currentPosition = (Console.CursorLeft, Console.CursorTop);
        (int leftDelta, int topDelta) proposedPosition = (Console.CursorLeft, Console.CursorTop);
        if(inputKey == ConsoleKey.Escape) {
            continuePlaying = false;
        }

        if (inputKey == ConsoleKey.UpArrow) 
            proposedPosition.topDelta--;
        else if (inputKey == ConsoleKey.DownArrow)
            proposedPosition.topDelta++;
        else if(inputKey == ConsoleKey.LeftArrow) 
            proposedPosition.leftDelta--;
        else if (inputKey == ConsoleKey.RightArrow)	
            proposedPosition.leftDelta++;
        
        bool withinMap = proposedPosition.leftDelta >= mapBounds["left"] && proposedPosition.leftDelta <= mapBounds["right"] && proposedPosition.topDelta >= mapBounds["top"] && proposedPosition.topDelta <= mapBounds["bottom"];
        bool notProjectedBlockedSpace = mapRows[proposedPosition.topDelta - verticalOffset][proposedPosition.leftDelta] != '#';
        if (withinMap && notProjectedBlockedSpace) {
            Console.SetCursorPosition(proposedPosition.leftDelta, proposedPosition.topDelta);
        }

        bool playerWon = mapRows[proposedPosition.topDelta - verticalOffset][proposedPosition.leftDelta] == '*';
        if (playerWon){
            Console.Clear();
            Console.WriteLine("YOU WON!");
            continuePlaying = false;
        }

    } while(continuePlaying);
};

Main();

// (Enforce walls) Update your TryMove code to additionally enforce that no move is taken if it would land the player on a '#' cell. (Make sure the program works and commit the changes to your repo.)

// (optional) (More Features) (5 bonus points each)
// Add a timer (remember that stopwatch function) and record how long it takes to complete the maze
// There is a maze part 2 where we will force a few more features on this game. No more bonuses until then.
