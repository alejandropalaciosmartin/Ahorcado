namespace Ahorcado
{
    class Program
    {
        static readonly string[] WORDS = { "coche", "barco", "moto", "bicicleta", "patinete electrico" };
        const int TRYS = 8;
        static void Main()
        {
            int trys = TRYS, win = 0;
            string word = ChooseWord();
            char[] wordChar = word.ToCharArray();
            char[] length = WriteDashes(word);
            string inputLetter = string.Empty;
            char inputLetterChar = ' ';
            string result = string.Empty;

            bool youWin = false;

            while (youWin == false)
            {
                int onlyOne = 0, cont = 8, repeat = 0;

                while (onlyOne == 0)
                {
                    Console.WriteLine("La palabra a adivinar: " + String.Join("", length));

                    Console.WriteLine("Intentos restantes: {0}", trys);

                    Console.Write("Letras usadas: ");

                    if (CheckOnlyOneLetter(inputLetter) && CheckIfLetterRepeat(result, inputLetter) && IsALetter(inputLetter))
                    { result += inputLetter; }

                    string finalword = SortLetters(result);
                    Console.WriteLine(finalword);

                    DrawGallow(trys);

                    Console.Write("\nIntroduce una letra: ");
                    inputLetter = Console.ReadLine().ToLower();

                    if (CheckOnlyOneLetter(inputLetter))
                    {
                        inputLetterChar = Convert.ToChar(inputLetter);
                        onlyOne++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write("Oye, Ingresa solo una letra.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                for (int k = 0; k < length.Length; k++)
                {
                    if (length[k] == inputLetterChar)
                    {
                        if (repeat == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Oye, letra ya encontrada, escribe otra.");
                            trys--;
                            Console.ReadKey();
                            repeat++;

                        }
                        cont--;
                    }
                    else
                        if (inputLetterChar == wordChar[k])
                        {
                            length[k] = inputLetterChar;
                            cont--;
                            win++;
                        }
                }
                if (cont == 8)
                    trys--;
                if (trys == 0)
                {
                    Console.Clear();
                    DrawGallow(trys);
                    Console.WriteLine("\nYa no hay intentos\nPerdiste...");
                    Console.ReadKey();
                    break;
                }
                if (word.Contains(' '))
                {
                    if (win == wordChar.Length - 1)
                        youWin = true;

                    Console.Clear();
                }
                else
                {
                    if (win == wordChar.Length)
                        youWin = true;

                    Console.Clear();
                }
            }
            WriteEndGame(word, trys, youWin);
        }
        //-----------------------------------------------------------------------------------------------------------------
        static string ChooseWord() => WORDS[new Random().Next(WORDS.Length)];
        //-----------------------------------------------------------------------------------------------------------------
        static char[] WriteDashes(string word) => word.Select(c => char.IsLetter(c) ? '-' : c).ToArray();
        //-----------------------------------------------------------------------------------------------------------------
        static bool CheckOnlyOneLetter(string word) => word.Length == 1;
        //-----------------------------------------------------------------------------------------------------------------
        static void WriteEndGame(string word, int trys, bool youWin)
        {
            Console.Clear();
            DrawGallow(youWin ? 0 : trys);
            Console.WriteLine();
            Console.WriteLine(youWin ? $"¡HAS GANADO! La palabra era: {word.ToUpper()}" : $"La palabra era: {word.ToUpper()}");
            Console.ReadKey();
        }
        //-----------------------------------------------------------------------------------------------------------------
        static void DrawGallow(int trys)
        {
            if (trys == 8) Console.Write("-" + "\n|" + "\n|" + "\n|" + "\n|" + "\n|" + "\n---");
            if (trys == 7) Console.Write("------" + "\n|" + "\n|" + "\n|" + "\n|" + "\n|" + "\n---");
            if (trys == 6) Console.Write("------" + "\n|   |" + "\n|" + "\n|" + "\n|" + "\n|" + "\n---");
            if (trys == 5) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|" + "\n|" + "\n|" + "\n---");
            if (trys == 4) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|   |" + "\n|" + "\n|" + "\n---");
            if (trys == 3) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|  /|" + "\n| " + "\n|" + "\n---");
            if (trys == 2) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|  /|\\" + "\n|" + "\n|" + "\n---");
            if (trys == 1) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|  /|\\" + "\n|  /" + "\n|" + "\n---");
            if (trys == 0) Console.Write("------" + "\n|   |" + "\n|   O" + "\n|  /|\\" + "\n|  / \\" + "\n|" + "\n---");
        }
        //-----------------------------------------------------------------------------------------------------------------
        static bool CheckIfLetterRepeat(string abc, string letter) => !abc.Contains(letter);
        //-----------------------------------------------------------------------------------------------------------------
        static bool IsALetter(string letter)
        {
            string alphabet = "abcdefghijklmnñopqrstuvwxyz";
            return alphabet.Contains(letter);
        }
        //-----------------------------------------------------------------------------------------------------------------
        static string SortLetters(string result)
        {
            char[] letters = result.ToCharArray();
            Array.Sort(letters);
            return "[" + new string(letters) + "]";
        }
    }
}