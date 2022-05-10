static class Game
{
     public static int CannonX { get; private set; }
     public static int CannonY { get; private set; }
     const uint Height = 5;
     const uint Width = 30;
     static Cell[,] _field = new Cell[Width, Height];
     static void DrawField()
     {
          Console.SetCursorPosition(0, 0);
          for (int column = 0; column < Width; column++)
          {
               for (int row = 0; row < Height; row++)
               {
                    char symbol;
                    switch (_field[column, row])
                    {
                         case Cell.Empty:
                              symbol = '*';
                              break;
                         case Cell.Cannon:
                              symbol = '^';
                              break;
                         case Cell.Projectile:
                              symbol = '!';
                              break;
                         default:
                              symbol = '?';
                              break;
                    }
                    Console.Write(symbol);
               }
               Console.WriteLine();
          }
     }
     static void ProcessInput()
     {
          try
          {
               switch (Console.ReadKey().Key)
               {
                    case ConsoleKey.Spacebar:
                         if (CannonX != _field.GetLength(0))
                         {
                              _field[CannonX + 1, CannonY] = Cell.Projectile;
                         }
                         break;
               }
          }
          catch
          {
               throw;
          }
     }
     static void ProcessLogic()
     {
          _field[CannonX, CannonY] = Cell.Cannon;
     }
     public static void RunGame()
     {
          CannonX = _field.GetLength(0) - 1;
          CannonY = 0;
          while (true)
          {
               DrawField();
               ProcessInput();
               ProcessLogic();
          }
     }
}