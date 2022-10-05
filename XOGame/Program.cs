using System;

namespace XOGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!!! Welcome to XOGame !!!");
            Console.WriteLine("Enter cordinates of grid where you want to put your symbol");
            Console.WriteLine("PRESS ENTER");
            Console.ReadKey();
            Console.Clear();
            PlayGame();
        }
        public static void PlayGame()
        {
            char[,] symbols = new char[3, 3]
               {
                    { '-', '-', '-' },
                    { '-', '-', '-' },
                    { '-', '-', '-' }
               };
            int count = 0;
            char mark = 'X';
            while (count < 9)
            {
                Console.Clear();
                Display(symbols);
                Console.WriteLine($"{mark} turn");
                Console.Write("Enter cordinates : ");
                string input = Console.ReadLine();
                string[] inputArr = input.Split(",");
                int row = Convert.ToInt32(inputArr[0]);
                int column = Convert.ToInt32(inputArr[1]);
                if (row > 3 || column > 3)
                {
                    Console.WriteLine("This cordinates doesn't exist, please check other!");
                    Console.WriteLine("PRESS ENTER");
                    Console.ReadKey();
                    continue;
                }
                if (symbols[row - 1, column - 1] != '-')
                {
                    Console.WriteLine("Cordinate is alredy full, please check other!");
                    Console.WriteLine("PRESS ENTER");
                    Console.ReadKey();
                    continue;
                }
                symbols[row - 1, column - 1] = mark;
                bool isWin = CheckWin(symbols);
                if (isWin)
                {
                    break;
                }
                if (mark == 'O')
                {
                    mark = 'X';
                }
                else if (mark == 'X')
                {
                    mark = 'O';
                }

                count += 1;
            }
            IsNewGame();
            
        }
        public static void Display(char[,] arr)
        {   
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + " " );      
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static bool CheckWin(char[,] arr)
        {
            char mark = 'X';
            for (int i = 0; i < 2; i++)
            {
                if (arr[0, 0] == mark && arr[0, 1] == mark && arr[0, 2] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[1, 0] == mark && arr[1, 1] == mark && arr[1, 2] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[2, 0] == mark && arr[2, 1] == mark && arr[2, 2] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[0, 0] == mark && arr[1, 0] == mark && arr[2, 0] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[0, 1] == mark && arr[1, 1] == mark && arr[2, 1] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[0, 2] == mark && arr[1, 2] == mark && arr[2, 2] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[0, 0] == mark && arr[1, 1] == mark && arr[2, 2] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                if (arr[0, 2] == mark && arr[1, 1] == mark && arr[2, 0] == mark)
                {
                    Console.WriteLine($"!!! {mark} WON !!!");
                    return true;
                }
                mark = 'O';
            }
            return false;
            
        }

        public static void IsNewGame()
        {
            Console.WriteLine("Do you want to play again ? ");
            Console.WriteLine("If yes write 'y' and press ENTER if no write 'n' and press ENTER");
            string wantNewGame = Console.ReadLine();

            if (wantNewGame == "y")
            {
                PlayGame();
            }
            else if (wantNewGame == "n")
            {
                Console.Clear();
                Console.WriteLine("Goodbye!!!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("We don't have another option PRESS ENTER");
                Console.ReadKey();
                Console.Clear();
                IsNewGame();
            }
        }

    }
}
