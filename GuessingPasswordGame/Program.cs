namespace CurseWork
{
    internal class Program
    {
        static void PrintArray(string[] array)
        {
            Console.WriteLine($"Список паролiв, якi складаються з {array[0].Length} символiв");
            int rows = 10;
            int columns = 3;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = i * columns + j;
                    if (index < array.Length)
                    {
                        Console.Write($"{array[index],-10} ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Rules()
        {    
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine(" ( \tПравила гри:\t\t\t\t\t\t\t\t\t\t\t\t )");
            Console.WriteLine("  ) \tВам дано 4 спроби щоб вгадати пароль з заданного списку паролiв\t\t\t\t\t\t(");
            Console.WriteLine(" ( \tПароль складається з лiтер англiйського алфавiту\t\t\t\t\t\t\t )");
            Console.WriteLine("  ) \tНа кожному кроцi комп’ютер повертає iнформацiю про кiлькiсть вгаданих лiтер, якi стоять на своєму мiсцi.(");
            Console.WriteLine(" ( \tВи можете вибирати складнiсть пiдбору\t\t\t\t\t\t\t\t\t )");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();

            Console.WriteLine("Виберiть рiвень складностi пiдбору паролю:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Натиснiть 1 для вибору легкого рiвня(пароль складається з 5 символiв)");
            Console.WriteLine("Натиснiть 2 для вибору середнього рiвня(пароль складається з 9 символiв)");
            Console.WriteLine("Натиснiть 3 для вибору важкого рiвня(пароль складається з 12 символiв)");
            Console.WriteLine("Натиснiть 0 для виходу з програми");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
        }

        static void CleaningMonitor() 
        {
            Console.WriteLine("Натиснiть будь-яку кнопку для того, щоб почати заново ...");
            Console.ReadKey();
            Console.Clear();
        }
        static string GetRandomElement(string[] array)
        {          
            string[] shuffledArray = FisherYatesShuffle(array);
            int randomIndex = array.Length - 1; 
            string randomElement = shuffledArray[randomIndex];

            return randomElement;
        }

        static string[] FisherYatesShuffle(string[] array)
        {
            Random random = new Random();
            int n = array.Length;

            string[] newArray = new string[n];

            do
            {
                int randomIndex = random.Next(0, n);
                n--;

                string temp = array[n];
                newArray[n] = array[randomIndex];
                newArray[randomIndex] = temp;
            } while (n > 1);

            return newArray;
        }

        static bool LinearSearch(string[] array, string target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    return true;
                }
            }
            return false;
        }

        static int CheckGuess(string password, string guess, string[] validPasswords)
        {
            bool contains = LinearSearch(validPasswords, guess);
            int correctCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] == guess[i])
                {
                    correctCount++;
                }

            }
            if (!contains)
            {
                Console.WriteLine("Введений пароль не належить списку паролiв");
            }
            else
            {
                Console.WriteLine($"Кiлькiсть лiтер якi стоять на своєму мiсцi: {correctCount}.");
            }

            return correctCount;
        }

        static void GuessingPassword(string password, string[] validPasswords)
        {
            bool passwordGuessed = false;
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"Спроба #{i}:");
                string guess = Console.ReadLine().ToUpper();

                if (guess.Length != password.Length)
                {
                    Console.WriteLine($"Будь ласка, введiть пароль довжиною {password.Length} лiтер.");
                    continue;
                }
                int correctCount = CheckGuess(password, guess, validPasswords);



                if (correctCount == password.Length)
                {
                    Console.WriteLine("Пароль вгадано!");
                    passwordGuessed = true;
                    break;
                }
            }

            if (!passwordGuessed)
            {
                Console.WriteLine($"Ви не вгадали пароль. Загаданий пароль: {password}");
                passwordGuessed = false;
            }
        }

        static void Main(string[] args)
        {

            string[] fiveSymbolPasswords = new string[]
            {
                "APPLE","STONE","ASIAN","ANGLE","MAGIC","MOUSE","CHIEF","HABIT","SHARP","MONEY",
                "HUMAN","BLOOM","TIGER","CRUEL","CLASS","BRASS","JENNA","FIRST","ATLAS","FIGHT",
                "GREEN","FIELD","SHARK","SMALL","ANIME","GRASS","ALICE","SCARF","HYGGE","JONES"
            };

            string[] nineSymbolPasswords = new string[]
            {
                "ACAPPELLA","DEPOSITOR","NAVIGATOR","BICYCLIST","INNOVATOR","COFOUNDER","DEVELOPER",
                "BAKERLIKE","DEBENTURE","SYNDICATE","VALENTINE","BILLBOARD","DECOUVERT","CONSENSUS",
                "INSURANCE","WARRANTOR","SOLISITOR","PRINCIPAL","OVERDRAFT","MIDDLEMAN","DECOUVERT",
                "COMMODITY","COFFEEMAN","AMENDMENT","ANALYZERS","XENOPHOBE","FREQUANCE","REVERSION",
                "EXCEPTION","OPERATION"
            };

            string[] twelveSymbolPasswords = new string[]
            {
                "OPTIMIZATION","UNEQUALIZING","POLYGAMIZING","HYPNOTIZABLE","ZYGOMORPHOUS","ORGANIZATION",
                "OCTOGENERIAN","CONFORMATION","ACHIEVEMENTS","YELLOWTHROAT","QUACKSALVERS","WATERGLASSES",
                "JETTISONABLE","SAFEGUARDING","SANITARINESS","BACKSCATTERS","CALLIGRAPHER","VACATIONISTS",
                "JUDGMENTALLY","KNEEBOARDERS","SUBJECTIVIST","ACCOUTREMENT","QUADROPHONIC","ZOOGEOGRAPHY",
                "BENZOAPYRENE","EQUIPOLLENCE","PRIZEFIGHTER","MYTHOLOGISTS","BACKBENCHERS","ROCKCLIMBING"
            };


            bool exit = false;
            do
            {
                Rules();
                string randomFiveSymbolPasword = GetRandomElement(fiveSymbolPasswords);
                string randomNineSynbolPassword = GetRandomElement(nineSymbolPasswords);
                string randomTwelveSymbolPassword = GetRandomElement(twelveSymbolPasswords);

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        PrintArray(fiveSymbolPasswords);
                        GuessingPassword(randomFiveSymbolPasword, fiveSymbolPasswords);
                        CleaningMonitor();
                        break;

                    case "2":
                        PrintArray(nineSymbolPasswords);
                        GuessingPassword(randomNineSynbolPassword, nineSymbolPasswords);
                        CleaningMonitor();
                        break;
                    case "3":
                        PrintArray(twelveSymbolPasswords);
                        GuessingPassword(randomTwelveSymbolPassword, twelveSymbolPasswords);
                        CleaningMonitor();
                        break;
                    case "0":
                        exit = true;
                        break;

                }
                

            } while (!exit);

        }
    }
}