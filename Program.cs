using System.Globalization;
using System.Xml.XPath;
using System.Text.Json;

internal class Program
{

  static int PlayerWins = 0;
  static int ComputerWins = 0;

  private static void Main()
  {
    LoadGame();
    Console.Clear();
    Console.WriteLine("Rock, Paper, Scissors!");
    string userHand = ChooseHand();
    string computerHand = GetComputerHand();
    Console.WriteLine($"You chose {userHand}");
    Console.WriteLine($"Computer rolled {computerHand}");

    if (userHand == computerHand)
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! It's a draw!!!");
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Rock" && computerHand == "Paper")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! The computer WINS!!!");
      ComputerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Rock" && computerHand == "Scissors")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! You WIN!!!");
      PlayerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Paper" && computerHand == "Rock")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! You WIN!!!");
      PlayerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Paper" && computerHand == "Scissors")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! The computer WINS!!!");
      ComputerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Scissors" && computerHand == "Rock")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! The computer WINS!!!");
      ComputerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }
    if (userHand == "Scissors" && computerHand == "Paper")
    {
      Console.WriteLine($"You chose {userHand} and the computer rolled {computerHand}! You WIN!!!");
      PlayerWins++;
      Console.WriteLine($"Score: Player {PlayerWins} | Computer {ComputerWins}");
    }

    Console.WriteLine("Do you want to play again?!? Y/N");
    var playAgain = Console.ReadKey().KeyChar;
    Console.WriteLine(playAgain);
    if (playAgain == 'N' || playAgain == 'n')
    {
      Console.WriteLine($"Final Scores: Player {PlayerWins} | Computer {ComputerWins}");
      return;
    }
    SaveGame();
    Main();
  }

  static string ChooseHand()
  {
    Console.Clear();
    Console.WriteLine("Choose a Hand");
    Console.WriteLine("1. Rock");
    Console.WriteLine("2. Paper");
    Console.WriteLine("3. Scissors");

    string? userInput = Console.ReadLine();

    if (userInput == "1")
    {
      return "Rock";
    }
    if (userInput == "2")
    {
      return "Paper";
    }
    if (userInput == "3")
    {
      return "Scissors";
    }
    Console.WriteLine("Invalid input! Choose again in 2 seconds...");
    Thread.Sleep(2000);
    return ChooseHand();
  }

  static string GetComputerHand()
  {
    int randomNumber = new Random().Next(1, 4);
    if (randomNumber == 1)
    {
      return "Rock";
    }
    if (randomNumber == 2)
    {
      return "Paper";
    }
    return "Scissors";
  }

  static void SaveGame()
  {
    SaveData save = new(PlayerWins, ComputerWins);
    string saveData = JsonSerializer.Serialize(save);
    File.WriteAllText("saveGame.json", saveData);
  }

  static void LoadGame()
  {
    bool fileExists = File.Exists("saveGame.json");
    if (!fileExists)
    {
      return;
    }
    string jsonString = File.ReadAllText("saveGame.json");
    SaveData? data = JsonSerializer.Deserialize<SaveData>(jsonString);
    if (data != null)
    {
      PlayerWins = data.PlayerWins;
      ComputerWins = data.ComputerWins;
    }
  }
}

internal class SaveData
{
  public int PlayerWins { get; set; }
  public int ComputerWins { get; set; }

  public SaveData(int playerWins, int computerWins)
  {
    PlayerWins = playerWins;
    ComputerWins = computerWins;
  }
}


