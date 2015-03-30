using System;
using System.Collections.Generic;
using System.Linq;

namespace Encryptor
{
  class Simulation
  {
    public const int ROWS = 20;
    public const int COLS = 45;
    public static List<List<Cell>> grid;
    private static int time = 0;

    static Simulation()
    {
      Console.WriteLine("Initializing simulation...");
      fillgrid();
    }

    public static void Start()
    {
      Console.WriteLine("Simulation Ready... (press any key)");
      Console.ReadKey();
      loop();
    }

    public static Cell Find(Position p)
    {
      return grid[p.Row][p.Col];
    }

    private static void loop()
    {
      moveAnimals();
      print();

      Console.WriteLine("Press any key to progress... (Ctrl + C to escape)");
      System.Threading.Thread.Sleep(200);

      time++;
      loop();
    }

    public static void Add(IAnimal animal)
    {
      if(!randomCell().TryAddAnimal(animal))
        Add(animal);
      else
        Console.WriteLine("Added " + animal.ToString());
    }

    private static void fillgrid()
    {
      List<List<Cell>> rows = new List<List<Cell>>();
      for(int r=0; r<ROWS; r++){
        List<Cell> row = new List<Cell>();
        for(int c=0; c<COLS; c++){
          row.Add(new Cell(r, c));
        }
        rows.Add(row);
      }
      grid = rows;
    }

    private static Cell randomCell()
    {
      return Find(Position.Random());
    }

    private static void print()
    {
      Console.Clear();
      Console.WriteLine("ROUND: " + time);
      foreach(List<Cell> row in grid)
      {
        foreach(Cell cell in row)
        {
          Console.Write(cell.ToChar());
        }
        Console.WriteLine();
      }
    }


    private static void moveAnimals()
    {
      List<Cell> queue = new List<Cell>();
      foreach(List<Cell> rows in grid)
        foreach(Cell cell in rows)
          if(cell.HasAnimal())
            queue.Add(cell);
      
      foreach(Cell cell in queue)
        cell.TryMoveAnimal();
    }
  }


  class Cell
  {
    private IAnimal animal;
    private Position position;

    public Cell(int row, int col) : this(new Position(row, col)){}

    public Cell(Position pos)
    {
      position = pos;
    }

    public bool TryAddAnimal(IAnimal a)
    {
      if(HasAnimal()) return false;

      animal = a;
      return  true;
    }

    public void TryMoveAnimal()
    {
      if(HasAnimal())
      {
        var neighbours = Utils.ShuffleList(position.Neighbours());
        foreach(Position p in neighbours)
        {
          Cell alt = Simulation.Find(p);
          if(alt.TryAddAnimal(animal)){
            animal = null;
            break;
          }
        }
      }
    }

    public bool HasAnimal()
    {
      return animal != null;
    }

    public char ToChar()
    {
      if(HasAnimal())
        return animal.ToChar(); 
      else
        return '_';
    }
  }



  class Position
  {
    static Random rnd = new Random();
    public int Row { get; private set; }
    public int Col { get; private set; }

    public Position(int row, int col)
    {
      Row = row;
      Col = col;
    }

    public List<Position> Neighbours()
    {
      List<Position> neighbours = new List<Position>(){
        Offset( 0, 1),
        Offset( 0,-1),
        Offset(-1, 0),
        Offset( 1, 0)
      };

      return neighbours.Where(
        p => p.IsValid()
        && (rnd.Next(0,10) > 5)
      ).ToList();
    }

    public static Position Random()
    {
      int r = rnd.Next(0, Simulation.ROWS-1);
      int c = rnd.Next(0, Simulation.COLS-1);
      return new Position(r, c);
    }

    public Position Offset(int row, int col)
    {
      return new Position(Row+row, Col+col);
    }

    public bool IsValid()
    {
      return Row >= 0
          && Col >= 0
          && Row < Simulation.ROWS
          && Col < Simulation.COLS;
    }
  }


  class Utils
  {
    public static List<Position> ShuffleList(List<Position> list)
    {
      Random rand = new Random();
      return list.OrderBy(p => rand.Next()).ToList();
    }
  }
}
