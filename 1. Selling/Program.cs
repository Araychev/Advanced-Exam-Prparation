using System;

namespace _1._Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int currRow = 0;
            int currCol = 0;
            int money = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colData[col].ToString();

                    if (matrix[row, col] == "S")
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            while (true)
            {
                string move = Console.ReadLine();
                switch (move)
                {
                    case "up":
                        matrix[currRow, currCol] = "-";
                        currRow--;

                        break;
                    case "down":
                        matrix[currRow, currCol] = "-";

                        currRow++;

                        break;
                    case "left":
                        matrix[currRow, currCol] = "-";

                        currCol--;

                        break;
                    case "right":
                        matrix[currRow, currCol] = "-";

                        currCol++;

                        break;
                }

                if (currRow < 0 || currRow > n-1 || currCol < 0 || currCol > n-1)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    Console.WriteLine($"Money: {money}");
                    PrintMatrix(matrix);
                    break;
                }
                if (matrix[currRow, currCol] == "O")
                {
                    matrix[currRow, currCol] = "-";
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == "O")
                            {
                                currRow = row;
                                currCol = col;
                            }
                        }
                    }

                }
                if (matrix[currRow, currCol] != "O" && matrix[currRow,currCol] != "-")
                {
                    money += int.Parse(matrix[currRow, currCol]);

                    if (money >= 50)
                    {
                        Console.WriteLine("Good news! You succeeded in collecting enough money!");
                        Console.WriteLine($"Money: {money}");
                        matrix[currRow, currCol] = "S";
                        PrintMatrix(matrix);
                        break;
                    }

                }


            }

        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
