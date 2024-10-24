using System;
using System.Threading;

class BreakoutGame
{
  static bool gameRunning = true;

  // Paddle variables
  static int paddleWidth = 10;
  static int paddlePositionX;
  static int paddlePositionY;

  // Ball variables
  static int ballPositionX;
  static int ballPositionY;
  static int ballDirectionX = 1;
  static int ballDirectionY = 1;

  static void Main(string[] args)
  {
    // Setup Console Window size
    int windowWidth = Console.WindowWidth;
    int windowHeight = Console.WindowHeight;
    Console.Clear();

    paddlePositionX = windowWidth / 2 - paddleWidth / 2;
    paddlePositionY = (int)(windowHeight * 0.8);

    ballPositionX = windowWidth / 2;
    ballDirectionY = windowHeight / 2;

    // Game loop
    while (gameRunning)
    {
        
      Console.Clear();

      DrawPaddle(windowWidth, windowHeight);
      DrawBall();

      MoveBall(windowWidth, windowHeight);
      
      HandleInput();
      
      Thread.Sleep(100);
    }
  }

  static void DrawPaddle(int windowWidth, int windowHeight)
  {
      
    int paddlePositionX = Math.Max(0, Math.Min(paddlePositionX, Console.BufferWidth - paddleWidth));
    int paddlePositionY = Math.Max(0, Math.Min(paddlePositionY, Console.BufferHeight - 1));

    Console.SetCursorPosition(paddlePositionX, paddlePositionY); 
    Console.Write(new string("=", paddleWidth));
  }

  static void DrawBall()
  {
    Console.SetCursorPosition(ballPositionX, ballPositionY);
    Console.Write("O");
  }

  static void MoveBall(int windowWidth, int windowHeight)
  {
    ballPositionX += ballDirectionX;
    ballPositionY += ballDirectionY;

    if (ballPositionX <= 0 || ballPositionX >= windowWidth -1)
    {
      ballDirectionX *= -1;
    }
    if (ballPositionY <= 0 || ballPositionY >= windowHeight - 1)
    {
      ballDirectionY *= - 1;
    }
  }

  static void HandleInput()
  {
    if (Console.KeyAvailable)
    {
      var key = Console.ReadKey(true).Key;

      if (key == ConsoleKey.Escape)
      {
          gameRunning = false; // Exit game
      }
        
    }
  }
}
