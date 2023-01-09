using System.Diagnostics;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("C:\\Users\\Administartor\\Downloads\\dane_wisielec.csv");

            Random rnd = new Random();

            string word = words[rnd.Next(words.Length)];

            char[] wordArray = word.ToCharArray();

            char[] gameState = new char[wordArray.Length];

            for (int i = 0; i < gameState.Length; i++)
            {
                gameState[i] = '_';
            }

            int mistakes = 0;

            bool solved = false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (!solved)
            {

                Console.WriteLine(gameState);

                Console.Write("Podaj literkę: ");
                Console.WriteLine("Liczba bledow " + mistakes);
                char letter = Console.ReadKey().KeyChar;
                Console.WriteLine();
                bool letterFound = false;

                for (int i = 0; i < wordArray.Length; i++)
                {
                    if (wordArray[i] == letter)
                    {
                        gameState[i] = letter;
                        letterFound = true;
                    }
                }

                if (!letterFound)
                {
                    mistakes++;
                }

                if (mistakes == 1)
                {
                    Console.WriteLine("===  ");
                }

                else if (mistakes == 2)
                {
                    Console.WriteLine(" | ");
                    Console.WriteLine("=== ");
                }

                else if (mistakes == 3)
                {
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("=== ");
                }

                else if (mistakes == 4)
                {
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("=== ");
                }

                else if (mistakes == 5)
                {
                    Console.WriteLine(" ___");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("=== ");
                }

                else if (mistakes == 6)
                {
                    Console.WriteLine(" ___");
                    Console.WriteLine(" | O");
                    Console.WriteLine(" | ");
                    Console.WriteLine(" | ");
                    Console.WriteLine("=== ");
                }
                else if (mistakes == 7)
                {
                    Console.WriteLine(" ___");
                    Console.WriteLine(" | O");
                    Console.WriteLine(" |/|\\");
                    Console.WriteLine(" |");
                    Console.WriteLine("=== ");
                }
                else if (mistakes == 8)
                {
                    Console.WriteLine(" ___");
                    Console.WriteLine(" | O");
                    Console.WriteLine(" |/|\\");
                    Console.WriteLine(" |/ \\");
                    Console.WriteLine("=== ");
                }

                else if (mistakes == 9)
                {
                    Console.WriteLine("Przegrałeś!");
                    break;
                }

                solved = true;
                for (int i = 0; i < gameState.Length; i++)
                {
                    if (gameState[i] == '_')
                    {
                        solved = false;
                        break;
                    }
                }
            }
            stopwatch.Stop();

            if (solved)
            {
                double score = (double)mistakes / wordArray.Length * 100;

                string elapsedTime = stopwatch.Elapsed.TotalSeconds.ToString();

                string result = string.Format("{0} ,{1} , {2} ", score, mistakes, elapsedTime);

                File.AppendAllText("C:\\Users\\Administartor\\Desktop\\results.csv", result + Environment.NewLine);
                Console.WriteLine("Gratulacje! Odgadłeś słowo");
            }
            else
            {
                Console.WriteLine("Slowo to: " + word);
            }
        }
    }
}


