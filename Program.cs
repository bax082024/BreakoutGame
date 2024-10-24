using System;
using System.Threading;

class BreakoutGame
{
    static bool gameRunning = true;

    // Paddle variables
    static int paddleWidth = 10;
    static int paddlePositionX = 0;
    static int paddlePositionY = 0;
    static int paddleSpeed = 2;

    // Ball variables
    static int ballPositionX;
    static int ballPositionY;
    static int ballDirectionX = 1;
    static int ballDirectionY = 1;
    static int ballSpeed = 5; 
    static int ballSpeedCounter = 0; 

    // Block variables
    static int blockRows = 3;
    static int blockCols = 10;
    static bool[,] blocks;

    static void InitializeBlocks()
    {
        blocks = new bool[blockRows, blockCols];
        for (int i = 0; i < blockRows; i++)
        {
            for (int j = 0; j < blockCols; j++)
            {
                blocks[i, j] = true;
            }
        }
    }
    
    static void Main(string[] args)
    {
        // Console Window size
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;
        Console.Clear();

        // paddle and ball positions
        paddlePositionX = windowWidth / 2 - paddleWidth / 2;
        paddlePositionY = (int)(windowHeight * 0.8);

        ballPositionX = windowWidth / 2;
        ballPositionY = windowHeight / 2;

        // Game loop
        while (gameRunning)
        {
            Console.Clear();

            DrawPaddle(windowWidth, windowHeight);
            DrawBall();

            // ball speed 
            ballSpeedCounter++;
            if (ballSpeedCounter >= ballSpeed)
            {
                MoveBall(windowWidth, windowHeight);
                ballSpeedCounter = 0; 
            }

            HandleInput(windowWidth);

            // Delay to slow down the game loop
            Thread.Sleep(20);
        }
    }

    static void DrawPaddle(int windowWidth, int windowHeight)
    {
        // paddle within the console buffer size
        paddlePositionX = Math.Max(0, Math.Min(paddlePositionX, Console.BufferWidth - paddleWidth));
        paddlePositionY = Math.Max(0, Math.Min(paddlePositionY, Console.BufferHeight - 1));

        // Draw the paddle at the current position
        Console.SetCursorPosition(paddlePositionX, paddlePositionY);
        Console.Write(new string('=', paddleWidth)); // Draw paddle
    }

    static void DrawBall()
    {
        // Draw the ball at the current position
        Console.SetCursorPosition(ballPositionX, ballPositionY);
        Console.Write("O"); 
    }

    static void MoveBall(int windowWidth, int windowHeight)
    {
        // Move the ball by updating its position
        ballPositionX += ballDirectionX;
        ballPositionY += ballDirectionY;

        // Ball bouncing logic
        if (ballPositionX <= 0 || ballPositionX >= windowWidth - 1)
        {
            ballDirectionX *= -1; 
        }
        if (ballPositionY <= 0)
        {
            ballDirectionY *= -1; 
        }

        // Ball and paddle collision 
        if (ballPositionY == paddlePositionY - 1 && ballPositionX >= paddlePositionX && ballPositionX <= paddlePositionX + paddleWidth)
        {
            ballDirectionY *= -1; 
        }

        // Game over if ball goes below the paddle
        if (ballPositionY >= windowHeight)
        {
            gameRunning = false;
            Console.Clear();
            Console.SetCursorPosition(windowWidth / 2 - 5, windowHeight / 2);
            Console.WriteLine("Game Over!");
        }
    }

    static void HandleInput(int windowWidth)
    {
        // Handle input 
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                gameRunning = false; 
            }

            // Paddle movement
            if (key == ConsoleKey.LeftArrow && paddlePositionX > 0)
            {
                paddlePositionX -= paddleSpeed; 
            }
            if (key == ConsoleKey.RightArrow && paddlePositionX < windowWidth - paddleWidth)
            {
                paddlePositionX += paddleSpeed; 
            }
        }
    }
}
