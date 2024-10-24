using System;
using System.Drawing;
using System.Threading;

class BreakoutGame
{
  static bool gameRunning = true;
  static int windowWidth = 800;
  static int windowHeight = 600;

  static void Main(string[] args)
  {
    // Console window size
    Console.SetWindowSize(windowWidth / 8, windowHeight / 20);
    Console.Clear();

    // Game loop
    while (gameRunning)
    {
      Console.Clear();

      DrawPaddle();

      HandleInput();

      Thread.Sleep(100);
    }

    static void DrawPaddle()
    {
      Console.SetCursorPosition(windowWidth / 2 - 5, windowHeight - 5);
      Console.Write("========")
    }

    static void HandleInput()
    {
      if (Console.KeyAvailable)
      {
        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.Escape)
        {
          gameRunning = false;
        }
      }
    }
  }
}