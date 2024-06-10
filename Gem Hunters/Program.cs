using System;
public class Position
{
    public int X{get;}
    public int Y{get;}
    public Position(int x,int y)
    {
        X = x; Y = y;
    }
}
public class Player
{
    public string Name { get; }
    public Position Position { get; set; }
    public int gemCount {  get; set; }  
    public Player(string name, Position position, int gemCount)
    {
        Name = name;
        this.Position = position;
        this.gemCount = gemCount;
    }
    public void Move(char direction)
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
            Position = new Position(Position.X + 1, Position.Y - 1);
        }
        else
        {
            Console.WriteLine("Invalid statement");
        }
    }
}
public class Cell
{
    public string Occupant { get; set; }
    public Cell( string Occupant)
    {
        Occupant = Occupant;
    }
}

public class Board
{
    private readonly Cell[,] Grid;
    public Board(Cell[,] grid )
    {
        Grid = new Cell[6, 6];
        InitializeBoard();
    }
    private void InitializeBoard()
    {
        for(int i=0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }
        Random obstacle = new Random();
        for(int i=0;i < 6; i++)
        {
            int x = obstacle.Next();
            int y = obstacle.Next();
            Grid[x, y] = new Cell("O");
        }
        Grid[0, 0].Occupant = "P1";
        Grid[5, 5].Occupant = "P2";

        for (int i = 0; i < 6; i++)
        {
            int x = obstacle.Next();
            int y = obstacle.Next();
            if(Grid[x, y].Occupant == "-")
            {
                Grid[x,y].Occupant = "G";
            }
            else
            {
                i--;
            }
        
        }
    }
}