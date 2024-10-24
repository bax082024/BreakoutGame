using System;
using System.Threading;

class BreakoutGame
{
    static bool gameRunning = true;

    // Paddle variables
    static int paddleWidth = 10;
    static int paddlePositionX = 0;
    static int paddlePositionY = 0;
    static int paddleSpeed = 2; // Paddle speed control

    // Ball variables
    static int ballPositionX;
    static int ballPositionY;
    static int ballDirectionX = 1;
    static int ballDirectionY = 1;
    static int ballSpeed = 5; // Ball speed control
    static int ballSpeedCounter = 0; // Counter to track when to move the ball

    static void Main(string[] args)
    {
        // Setup Console Window size
        int windowWidth = Console.WindowWidth;
        int windowHeight = Console.WindowHeight;
        Console.Clear();

        // Initialize paddle and ball positions
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

            // Handle ball speed independently
            ballSpeedCounter++;
            if (ballSpeedCounter >= ballSpeed)
            {
                MoveBall(windowWidth, windowHeight);
                ballSpeedCounter = 0; // Reset the counter after moving the ball
            }

            HandleInput(windowWidth);

            // Delay to slow down the game loop
            Thread.Sleep(20);
        }
    }

    static void DrawPaddle(int windowWidth, int windowHeight)
    {
        // Ensure the paddle stays within the console buffer size
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
        Console.Write("O"); // Ball represented as 'O'
    }

    static void MoveBall(int windowWidth, int windowHeight)
    {
        // Move the ball by updating its position
        ballPositionX += ballDirectionX;
        ballPositionY += ballDirectionY;

        // Ball bouncing logic
        if (ballPositionX <= 0 || ballPositionX >= windowWidth - 1)
        {
            ballDirectionX *= -1; // Reverse direction when hitting left/right walls
        }
        if (ballPositionY <= 0)
        {
            ballDirectionY *= -1; // Reverse direction when hitting the top wall
        }

        // Ball and paddle collision detection
        if (ballPositionY == paddlePositionY - 1 && ballPositionX >= paddlePositionX && ballPositionX <= paddlePositionX + paddleWidth)
        {
            ballDirectionY *= -1; // Bounce back up when hitting the paddle
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
        // Handle input directly, continuously moving the paddle while the arrow keys are pressed
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
            {
                gameRunning = false; // Exit game
            }

            // Paddle movement
            if (key == ConsoleKey.LeftArrow && paddlePositionX > 0)
            {
                paddlePositionX -= paddleSpeed; // Move left
            }
            if (key == ConsoleKey.RightArrow && paddlePositionX < windowWidth - paddleWidth)
            {
                paddlePositionX += paddleSpeed; // Move right
            }
        }
    }
}
