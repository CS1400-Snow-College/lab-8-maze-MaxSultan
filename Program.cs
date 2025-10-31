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
        (int leftDelta, int topDelta) proposedPosition = (Console.CursorLeft, Console.CursorTop);
        if(inputKey == ConsoleKey.Escape) 
            break;

        if (inputKey == ConsoleKey.UpArrow) 
            proposedPosition.topDelta--;
        else if (inputKey == ConsoleKey.DownArrow)
            proposedPosition.topDelta++;
        else if(inputKey == ConsoleKey.LeftArrow) 
            proposedPosition.leftDelta--;
        else if (inputKey == ConsoleKey.RightArrow)	
            proposedPosition.leftDelta++;
        
        bool withinMap = proposedPosition.leftDelta > mapBounds["left"] && proposedPosition.leftDelta <= mapBounds["right"] && proposedPosition.topDelta >= mapBounds["top"] && proposedPosition.topDelta <= mapBounds["bottom"];
        if (!withinMap) continue;
        bool notProjectedBlockedSpace = mapRows[proposedPosition.topDelta - verticalOffset][proposedPosition.leftDelta] != '#';
        if (!notProjectedBlockedSpace) continue;
        
        Console.SetCursorPosition(proposedPosition.leftDelta, proposedPosition.topDelta);

        bool playerWon = mapRows[proposedPosition.topDelta - verticalOffset][proposedPosition.leftDelta] == '*';
        if (playerWon){
            Console.Clear();
            Console.WriteLine("YOU WON!");
            break;
        }

    } while(true);
};

Main();