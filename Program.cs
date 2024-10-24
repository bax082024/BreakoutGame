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
    Console.SetWindowSize(windowWidth / 8, windowHeight / 20);
    Console.Clear();

    while (gameRunning)
    {
      Console.Clear();

      DrawPaddle();
    }
  }
}