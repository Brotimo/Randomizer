namespace What_to_play
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Game[] gameList = new Game[10];

            int gamesCounter = 0;

            string startMessage = "\t\t\tW co chcesz zagrać? Maszyna podejmie decyzję za Ciebie !!\n\t\t\t\tWybierz za pomocą cyfr co chcesz zrobić\n\n" +
                "1)Dodaj nową grę\n2)Rozpocznij losowanie\n3)Wyświetl wpisane gry\n4)Kasowanie aktualniej listy gier\n5)Help\nEsc)EXIT";
            while (true)
            {
                Console.WriteLine(startMessage);

                ConsoleKeyInfo decision = Console.ReadKey(true);
                switch (decision.Key)
                {

                    case ConsoleKey.D1:
                        {

                            Console.Clear();
                            Game newGame = new Game();
                            newGame.SetGameTitle();

                            if (gamesCounter < gameList.Length)
                            {
                                gameList[gamesCounter] = newGame;
                                gamesCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Nie można wpisać więcej gier");
                                BackToMainMenu();
                            }
                            BackToMainMenu();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Clear();

                            if (gamesCounter == 0)
                            {
                                Console.WriteLine("BŁĄD - Musisz wpisać jakąś grę!");
                                BackToMainMenu();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Do ilu chcesz losować?");
                                int numberOfDraws;
                                Random random = new Random();
                                try
                                {
                                    numberOfDraws = int.Parse(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("BŁĄD - Proszę wpisać liczbę całkowitą!");
                                    BackToMainMenu();
                                    break;
                                }
                                while (true)
                                {
                                    int randomInt = random.Next(0, gamesCounter);

                                    if (numberOfDraws > 0)
                                    {
                                        Console.Clear();
                                        gameList[randomInt].Score++;
                                        Console.WriteLine($"Wylosowano: {gameList[randomInt].Name} z wynikiem: {gameList[randomInt].Score}\n\n");
                                        if (gameList[randomInt].Score == numberOfDraws)
                                        {
                                            Console.WriteLine($"\n\nWYGRYWA {gameList[randomInt].Name} !!!");
                                            for (int i = 0; i < gameList.Length; i++)
                                            {
                                                if (gameList[i] != default(Game))
                                                {
                                                    gameList[i].Score = 0;
                                                }
                                            }
                                            BackToMainMenu();
                                            break;
                                        }
                                        Console.ReadKey(true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("BŁĄD - Wpisano liczbę 0 lub mniejszą!");
                                        BackToMainMenu();
                                        break;
                                    }
                                }

                            }
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.Clear();
                            int n = 1;
                            if (gameList[0] == null)
                            {
                                Console.WriteLine("Brak gier do wyświetlenia");
                                BackToMainMenu();
                                break;
                            }
                            foreach (Game game in gameList)
                            {
                                if (game != null)
                                {
                                    Console.WriteLine($"{n}:\t" + game.Name);
                                    n++;
                                }
                            }
                            BackToMainMenu();
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.Clear();
                            if (gameList[0] == null)
                            {
                                Console.WriteLine("Brak gier do skasowania");
                                Console.WriteLine("Nastąpi powrót do menu głównego");
                                BackToMainMenu();
                                break;
                            }
                            Console.WriteLine("Czy napewno chcesz skasować zapisane gry?(y/n)");
                            ConsoleKeyInfo key = Console.ReadKey(true);

                            if (key.Key == ConsoleKey.Y)
                            {
                                Array.Clear(gameList);
                                gamesCounter = 0;
                                Console.WriteLine("Pomyślnie skasowano listę gier!");
                                BackToMainMenu();
                                break;
                            }
                            else if (key.Key == ConsoleKey.N)
                            {
                                Console.Clear();
                                Console.WriteLine("Nastąpi powrót do menu głównego");
                                BackToMainMenu();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Dokonano złego wyboru - nastąpi powrót do menu głównego");
                                BackToMainMenu();
                                break;
                            }
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\t\t\t Opis opcji do wyboru:\n\n1 - Dodawanie gier w zakresie od 2 do 100 słów, maksymalnie można wpisać do 10 gier\n" +
                                "2 - Prosi użytkownika o liczbę do której ma się odbyć losowanie, a następnie je rozpoczyna\n3 - Wyświetla listę wpisanych gier\n4 - Kasuje wszystkie wpisane gry\n" +
                                "Esc - Opuszczenie programu");
                            BackToMainMenu();
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            Console.Clear();
                            Console.WriteLine("Czy na pewno chcesz opuścić program?(y/n)");
                            ConsoleKeyInfo key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Y)
                            {
                                Console.Clear();
                                Console.WriteLine("\t\t\t\tDziekuje za skorzystanie z mojego programu.\n\t\t\t\tŻyczę miłego dnia i smacznej kawusi!");
                                return;
                            }
                            else if (key.Key == ConsoleKey.N)
                            {
                                Console.Clear();
                                Console.WriteLine("Nastąpi powrót do menu głównego");
                                BackToMainMenu();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Dokonano złego wyboru - nastąpi powrót do menu głównego");
                                BackToMainMenu();
                                break;
                            }
                        }

                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Proszę o wybranie poprawnej opcji");
                            BackToMainMenu();
                            break;
                        }
                }
            }

        }
        static void BackToMainMenu()
        {
            Console.WriteLine("\nWciśnij dowolny przycisk aby kontynuować...");
            Console.ReadKey();
            Console.Clear();
        }

    }
}