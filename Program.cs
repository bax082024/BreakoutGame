using System;
using System.Threading;

class BreakoutGame
{
    static bool gameRunning = true;

    static void Main(string[] args)
    {
        // Setup Console Window size
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;
        Console.Clear();

        // Game loop
        while (gameRunning)
        {
            // Clear the console window for the next frame
            Console.Clear();

            // Render the game (this will include the paddle, ball, and blocks later)
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
            // Later we will handle moving the paddle here
        }
    }
}
