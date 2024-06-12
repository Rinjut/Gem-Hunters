using System;

//position class represents X,Y Co-ordinates
public class Position
{
    public int X{get;}
    public int Y{get;}
    public Position(int x,int y) // Constructor
    {
        X = x; Y = y;
    }
}
public class Player //Player class
{
    public string Name { get; }
    public Position Position { get; set; }
    public int gemCount {  get; set; }  
    public Player(string name, Position position) //Player class constructor
    {
        Name = name;
        Position = position;
        gemCount = 0;
    }

    public void Move(char direction)// Method 'Move' moves the player in the given direction
    {
        if(direction == 'U')
        {
            Position = new Position(Position.X,Position.Y - 1);
        }
        else if (direction == 'D')
        {
            Position = new Position(Position.X, Position.Y + 1);
        }
        else if (direction == 'L')
        {
            Position = new Position(Position.X - 1, Position.Y);
        }
        else if (direction == 'R')
        {
            Position = new Position(Position.X + 1, Position.Y);
        }
        else
        {
            Console.WriteLine("Invalid Direction");
        }
    }
}
public class Cell  // Cell class represent cells in the board
{
    public string Occupant { get; set; } //Respresent cells "P1","P2","O',"G'
    public Cell(string occupant) // Constuctor initializes cells occupant
    {
        Occupant = occupant;
    }
}

public class Board // Board class defines game board with 6*6 cells
{
    private readonly Cell[,] Grid;
    public Board() //Constructor : initialize initial position of cell occupant
    {
        Grid = new Cell[6, 6];
        InitializeBoard();
    }

    private void InitializeBoard() //Method 'InitializeBoard' defines random posiioning of players,Gem and obstacles
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }
        Random obstacle = new Random();
        for (int i = 0; i < 6; i++)
        {
            int x = obstacle.Next(6);
            int y = obstacle.Next(6);
            Grid[x, y] = new Cell("O");
        }
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

        for (int i = 0; i < 6; i++)
        {
            int x = obstacle.Next(6);
            int y = obstacle.Next(6);
            if (Grid[x, y].Occupant == "-")
            {
                Grid[x, y].Occupant = "G";
            }
            else
            {
                i--;
            }

        }
    }

    public void Display() // Method 'Display' print the current stage of board to console.
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j].Occupant + " ");
            }
            Console.WriteLine();
        }
    }
    public bool IsValidMove(Player player, char direction) // Method 'IsValidMove' check the movement of players is valid.
    {
        int destX = player.Position.X;
        int destY = player.Position.Y;
        if (direction == 'U')
        {
            destY--;
        }
        else if (direction == 'D')
        {
            destY++;
        }
        else if (direction == 'L')
        {
            destX--;
        }
        else if (direction == 'R')
        {
            destX++;
        }
        else
        {
            Console.WriteLine("Incorrect Movement");
            return false;
        }
        if (destX < 0 || destX >= 6 || destY < 0 || destY >= 6)
        {
            return false;
        }
        if (Grid[destY, destX].Occupant == "O")
        {
            return false;
        }
        return true;
    }
    public void IsMove(Player player, char direction) // Method 'IsMove' validate player's movement ,update players position, and count gem collection.
    {
        {
            if (IsValidMove(player, direction))
            {
                int destX = player.Position.X;
                int destY = player.Position.Y;
                if (direction == 'U')
                {
                    destY--;
                }
                else if (direction == 'D')
                {
                    destY++;
                }
                else if (direction == 'L')
                {
                    destX--;
                }
                else if (direction == 'R')
                {
                    destX++;
                }
                if (Grid[destY, destX].Occupant == "G")
                {
                    player.gemCount++;
                    Grid[destY, destX].Occupant = "-";
                }
                Grid[player.Position.Y, player.Position.X].Occupant = "-";
                Grid[destY, destX].Occupant = player.Name;
                player.Position= new Position(destX, destY);
            }

        }
    }

    public class Game // Game class manage overall game and its players
    {
        private Board Board;
        private Player Player1;
        private Player Player2;
        private Player CurrentTurn;
        private int TotalTurns;

        public Game() // constructor sets the initial board , position the players ,set player 1 as first turn
        {
            Board = new Board();
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        public void Start() // Method 'start' starts the game and handle IsGameOver,IsMove,SwitchTurn
        {
            while (!IsGameOver())
            {
                Board.Display();
                Console.WriteLine($"Current Turn:"+ CurrentTurn.Name);
                Console.Write("Enter move (U/D/L/R): ");
                char direction = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                if (direction == 'U' || direction == 'D' || direction == 'L' || direction == 'R')
                {
                    Board.IsMove(CurrentTurn, direction);
                    TotalTurns++;
                    SwitchTurn();
                }
                else
                {
                    Console.WriteLine("Invalid Direction!");
                }
            }
            AnnounceWinner();
        }

        private void SwitchTurn()  //method 'SwitchTurn' switches player's turn.
        {
            if(CurrentTurn == Player1)
            {
                CurrentTurn = Player2;
            }
            else
            {
                CurrentTurn = Player1;
            }
        }

        private bool IsGameOver() //Method 'IsGameOver' check total turns
        {
            return TotalTurns >= 30;
        }

        private void AnnounceWinner() //Method 'AnnounceWinner' announce winner based on individual gem count
        {
            Console.WriteLine("Game over!");
            Console.WriteLine("Player 1 Gems:{0}", Player1.gemCount);
            Console.WriteLine("Player 2 Gems:{0}", Player2.gemCount);
            if (Player1.gemCount > Player2.gemCount)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (Player2.gemCount > Player1.gemCount)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }

    class Program // main class to start the game.
    {
        static void Main(string[] args)
        {
            Game Game = new Game();
            Game.Start();
        }

    }
}
