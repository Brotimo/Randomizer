namespace What_to_play
{
    internal class Game
    {
        private string name { get; set; }
        private int score { get; set; }
        public string Name
        {
            get { return name; }

            set
            {
                name = value.ToUpper();
            }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public void SetGameTitle()
        {
            while (true)
            {
                Console.WriteLine("Podaj nazwę gry:");
                try
                {
                    Name = Console.ReadLine();

                    if (Name.Length <= 0 || Name.Length >= 100)
                    {
                        Console.WriteLine("Zbyt mała lub zbyt duża liczba znaków");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"\nPomyślnie dodano nazwę gry {name.ToUpper()}");
                    }
                    break;

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Proszę podać poprawną nazwę gry!\n");
                    break;
                }
            }
        }
    }
}
