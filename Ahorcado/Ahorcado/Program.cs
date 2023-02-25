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
                    {
                        if (inputLetterChar == wordChar[k])
                        {
                            length[k] = inputLetterChar;
                            cont--;
                            win++;
                        }
                    }
                }
                if (cont == 8)
                {
                    trys--;
                }
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
                    {
                        youWin = true;
                    }
                    Console.Clear();
                }
                else
                {
                    if (win == wordChar.Length)
                    {
                        youWin = true;
                    }
                    Console.Clear();
                }
            }
            WriteEndGame(word, trys, youWin);
        }
        static string ChooseWord()
        {
            Random random = new Random();
            int n = random.Next(0, 5);
            
            string find = WORDS[n];
            return find;
        }
        static char[] WriteDashes(string word)
        {
            char[] length = word.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (length[i] == ' ')
                {
                    length[i] = ' ';
                }
                else
                {
                    length[i] = '-';
                }
            }
            return length;
        }
        static bool CheckOnlyOneLetter(string word)
        {
            bool oneLetter = false;
            if (word.Length == 1)
            {
                oneLetter = true;
            }
            return oneLetter;
        }
        static void WriteEndGame(string word, int trys, bool youWin)
        {
            if (youWin == true)
            {
                DrawGallow(trys);
                Console.WriteLine();
                Console.WriteLine("¡HAS GANADO! La palabra era: {0}", word.ToUpper());
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("La palabra era: {0}", word.ToUpper());
                Console.ReadKey();
            }
        }
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
        static bool CheckIfLetterRepeat(string abc, string letter)
        {
            bool result;
            if (abc.Contains(letter)) result = false;
            else result = true;
            
            return result;
        }
        static bool IsALetter(string letter)
        {
            bool result;
            string alphabet = "abcdefghijklmnñopqrstuvwxyz";
            
            if (alphabet.Contains(letter)) result = true;
            else result = false;
 
            return result;
        }
        static string SortLetters(string result)
        {
            char[] letters = new char[result.Length];
            for (int x = 0; x < result.Length; x++)
            {
                letters[x] = result[x];
            }

            for (int i = 0; i < letters.Length; i++)
            {
                for (int j = i + 1; j < letters.Length; j++)
                {
                    char aux;
                    if (letters[i] > letters[j])
                    {
                        aux = letters[i];
                        letters[i] = letters[j];
                        letters[j] = aux;
                    }
                }
            }
            string sort3 = "[" + String.Join(",", letters) + "]";
            return sort3;
        }
    }
}