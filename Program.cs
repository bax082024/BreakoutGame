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
            // Clear the console window for the next frame
            Console.Clear();

            // Render the game 
            DrawPaddle(windowWidth, windowHeight);

            // Handle Input
            HandleInput();

            // Delay to slow down the game loop
            Thread.Sleep(100);
        }
    }

    static void DrawPaddle(int windowWidth, int windowHeight)
    {
        // Ensure the paddle is within the console buffer size
        int paddlePositionX = Math.Max(0, Math.Min(windowWidth / 2 - 5, Console.BufferWidth - 10));
        int paddlePositionY = Math.Max(0, Math.Min(windowHeight - 2, Console.BufferHeight - 1));

        Console.SetCursorPosition(paddlePositionX, paddlePositionY); // Position near the bottom
        Console.Write("========"); // Paddle size
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
