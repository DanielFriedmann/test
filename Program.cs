Menu();


void Menu()
{
    Console.WriteLine("======================================================================");
    Console.WriteLine("Willkommen im Warm-Kalt Spiel!");
    Console.WriteLine("======================================================================");
    Console.WriteLine("Wähle deinen Schwierigkeitsgrad:");
    Console.WriteLine("1 - Einfach (Zahlen von 1 bis 100)");
    Console.WriteLine("2 - Schwer (Zahlen von 1 bis 1000)");
    Console.WriteLine("3 - I have no life (Zahlen von 1 bis 100000)");
    Console.WriteLine("4 - Sogar Satan hat Angst vor dir (Zahlen von 1 bis 1 Million)");
    Console.WriteLine("5 - Custom Range (Zahlen von 1 bis X)");
    Console.WriteLine("=======================================================================");
    Console.WriteLine("6 - Highscore: TBD");

    string? difficultyInput = Console.ReadLine();

    if (difficultyInput != null)
    {

        switch (difficultyInput)
        {
            case "1":
                GameTotal(100);
                return;
            case "2":
                GameTotal(1000);
                return;
            case "3":
                GameTotal(100000);
                return;
            case "4":
                GameTotal(1000000);
                return;
            case "5":
                Console.WriteLine("Gib die obere Grenze für den Zahlenbereich ein (mindestens 10):");
                string? customInput = Console.ReadLine();
                if (customInput != null && int.TryParse(customInput, out int customRange) && customRange >= 10)
                {
                    GameTotal(customRange);
                    return;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ungültige Eingabe, bitte eine Zahl größer oder gleich 10 eingeben.");
                    Console.ResetColor();
                    return;
                }

            default:
                break;

        }


        /*else if (difficultyInput == "4")
        {
            Highscore();
            Console.WriteLine("=== Highscore Einfach ===");
            Array.Sort(highscoreEasy);
            Console.WriteLine(string.Join("\n", highscoreEasy));
            Console.WriteLine("=== Highscore Schwer ===");
            Console.WriteLine(string.Join("\n", highscoreHard));
            Console.WriteLine("=== Highscore No Life ===");
            Console.WriteLine(string.Join("\n", highscoreNoLife));
        }*/



    }

}

void GameTotal(int difficulty)
{

    Random random = new Random();
    int numberToGuess = random.Next(1, difficulty + 1);
    int[] userGuesses = new int[difficulty];
    bool guessedCorrectly = false;
    int counter = 0;
    string? readResult;
    int attempts = 0;

    Console.WriteLine($"Gib eine Zahl zwischen 1 und {difficulty} ein.");
    readResult = Console.ReadLine();


    if (readResult != null)
    {
        if (int.TryParse(readResult, out int zahl) && zahl <= difficulty)
        {
            userGuesses[counter] = zahl;
            attempts++;

            do
            {
                Console.WriteLine("Gib eine weitere Zahl ein und ich sage dir ob du näher (wärmer) oder weiter entfernt (kälter) bist");
                readResult = Console.ReadLine();


                if (int.TryParse(readResult, out int zahl1) && zahl1 <= difficulty)
                {
                    counter++;
                    userGuesses[counter] = zahl1;


                    if (userGuesses[counter] == numberToGuess)
                    {
                        attempts++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Glückwunsch! {userGuesses[counter]} ist die richtige Zahl! Versuche: {attempts}\a");
                        Console.ResetColor();
                        guessedCorrectly = true;
                        Console.Write("Deine Eingaben:");
                        foreach (var item in userGuesses)
                        {
                            if (item != 0)
                            {
                                Console.Write($" {item}");
                            }
                        }

                        /* Console.WriteLine("Gib deinen Namen für den Highscore ein:");
                         string? nameInput = Console.ReadLine();
                         if (nameInput != null)
                         {
                             highscoreEasy[9] = $"{attempts}, {nameInput}";
                             Array.Sort(highscoreEasy);
                             Console.WriteLine(string.Join("\n", highscoreEasy));
                         } */
                    }

                    else if (Math.Abs(userGuesses[counter - 1] - numberToGuess) > Math.Abs(userGuesses[counter] - numberToGuess))
                    {
                        attempts++;
                        Console.WriteLine("wärmer\n");
                    }

                    else if (Math.Abs(userGuesses[counter - 1] - numberToGuess) < Math.Abs(userGuesses[counter] - numberToGuess))
                    {
                        attempts++;
                        Console.WriteLine("kälter\n");
                    }

                    else if (Math.Abs(userGuesses[counter - 1] - numberToGuess) == Math.Abs(userGuesses[counter] - numberToGuess))
                    {
                        attempts++;
                        Console.WriteLine("Nicht wärmer und nicht kälter\n");
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ungültige Eingabe, nur Zahlen von 1 bis {difficulty}!");
                    Console.ResetColor();
                    guessedCorrectly = false;
                }






            } while (!guessedCorrectly);
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ungültige Eingabe, nur Zahlen von 1 bis {difficulty}!");
            Console.ResetColor();

        }



    }
}

void Highscore()
{

    /*string[] highscoreEasy = new string[10];
    string[] highscoreHard = new string[10];
    string[] highscoreNoLife = new string[10];

    //Default Highscores:
    highscoreEasy[0] = "200 Daniel";
    highscoreHard[0] = "45 Daniel";
    highscoreNoLife[0] = "120 Daniel";
    highscoreEasy[1] = "20 Anna";
    highscoreHard[1] = "50 Anna";
    highscoreNoLife[1] = "150 Anna";
    highscoreEasy[2] = "25 Max";
    highscoreHard[2] = "60 Max";
    highscoreNoLife[2] = "180 Max";
    highscoreEasy[3] = "30 Lisa";
    highscoreHard[3] = "70 Lisa";
    highscoreNoLife[3] = "200 Lisa";






*/

}