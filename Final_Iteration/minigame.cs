using System;

using System;
using System.Drawing;
using System.Windows.Forms;

public class MiniGameForm : Form
{
    private MiniGame miniGame;

    public MiniGameForm()
    {
        miniGame = new MiniGame();
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        this.Text = "BigBag Game";
        this.Size = new Size(400, 200);
        this.StartPosition = FormStartPosition.CenterScreen;

        Label titleLabel = new Label
        {
            Text = "Welcome to the BigBag Game!",
            AutoSize = true,
            Location = new Point(100, 20),
            Font = new Font("Arial", 16, FontStyle.Bold),
            ForeColor = Color.Black
        };
        this.Controls.Add(titleLabel);

        Button startButton = new Button
        {
            Text = "Start Game",
            Size = new Size(100, 40),
            Location = new Point(150, 80)
        };
        startButton.Click += StartButton_Click;
        this.Controls.Add(startButton);
    }

    private void StartButton_Click(object sender, EventArgs e)
    {

        try
        {
            miniGame.StartGame(); // Start the mini-game when the button is clicked
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
       
    }
}



public class MiniGame
{
    private int secretNumber;
    private bool gameWon;

    public MiniGame()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        Random random = new Random();
        secretNumber = random.Next(1, 101); // Generate a random number between 1 and 100
        gameWon = false;
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("Try to guess the secret number between 1 and 100.");

        while (!gameWon)
        {
            Console.Write("Enter your guess: ");
            if (int.TryParse(Console.ReadLine(), out int guess))
            {
                CheckGuess(guess);
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

    private void CheckGuess(int guess)
    {
        if (guess == secretNumber)
        {
            Console.WriteLine("Congratulations! You guessed the secret number.");
            gameWon = true;
        }
        else if (guess < secretNumber)
        {
            Console.WriteLine("Too low! Try again.");
        }
        else
        {
            Console.WriteLine("Too high! Try again.");
        }
    }

    // public void ExitGame()
    // {
    //     // Clean up or save game state if needed
    //     // This method can be called to exit the mini-game
    // }
}
