// Max Sultan, October 30th, Lab 8: Maze




// (Load from file) Within your Main method, 
// create a string array variable called mapRows and 
// use File.ReadAllLines to load the contents of map.txt into your variable. 
// Clear the screen, and then write a loop to print out the rows of the map to the screen. 
// (Make sure the program works and commit the changes to your repo.)

void DrawMap(){
    string[] mapRows = File.ReadAllLines("./map.txt");
    foreach(string row in mapRows)
        Console.WriteLine(row);
}

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
    DrawMap();
    Console.CursorLeft = 0;
    Console.CursorTop = 6;
    bool continuePlaying = true;
    do {
        ConsoleKey inputKey = Console.ReadKey(true).Key;
        if(inputKey == ConsoleKey.Escape) {
            continuePlaying = false;
        }
        if (inputKey == ConsoleKey.UpArrow) Console.CursorTop--;
        else if (inputKey == ConsoleKey.DownArrow) Console.CursorTop++;
        else if(inputKey == ConsoleKey.LeftArrow) Console.CursorLeft--;
        else if (inputKey == ConsoleKey.RightArrow)	Console.CursorLeft++;
    } while(continuePlaying);
};

Main();