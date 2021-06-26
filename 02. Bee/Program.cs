using System;

namespace _02._Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int currRow = 0;
            int currCol = 0;
            int pollinatedFlowers = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colData[col].ToString();

                    if (matrix[row, col] == "B")
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
            string input = Console.ReadLine();

            while (input != "End")
            {

                matrix[currRow, currCol] = ".";
                currRow = MoveRow(currRow, input);
                currCol = MoveCol(currCol, input);

                if (!IsPositionValid(currRow, currCol, n, n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                if (matrix[currRow, currCol] == "f")
                {
                    pollinatedFlowers++;
                }
                if (matrix[currRow, currCol] == "O")
                {
                    matrix[currRow, currCol] = ".";
                    currRow = MoveRow(currRow, input);
                    currCol = MoveCol(currCol, input);

                    if (!IsPositionValid(currRow, currCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[currRow, currCol] == "f")
                    {
                        pollinatedFlowers++;
                    }

                }

                matrix[currRow, currCol] = "B";
                input = Console.ReadLine();

            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");

            }

            PrintMatrix(matrix);

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


            static int MoveRow(int row, string movement)
            {
                if (movement == "up")
                {
                    return row - 1;
                }
                if (movement == "down")
                {
                    return row + 1;
                }
                return row;
            }

            static int MoveCol(int col, string movement)
            {
                if (movement == "left")
                {
                    return col - 1;
                }
                if (movement == "right")
                {
                    return col + 1;
                }
                return col;
            }

            static bool IsPositionValid(int row, int col, int rows, int cols)
            {
                if (row < 0 || row >= rows)
                {
                    return false;
                }
                if (col < 0 || col >= cols)
                {
                    return false;
                }

                return true;

            }


        }
    }
}




