using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nuberOfCmd = int.Parse(Console.ReadLine());

            string[,] matrix = new string[n, n];

            int currRow = 0;
            int currCol = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string colData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = colData[col].ToString();

                    if (matrix[row, col] == "f")
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            matrix[currRow, currCol] = "-";


            for (int i = 0; i < nuberOfCmd; i++)
            {

                string move = Console.ReadLine();
                switch (move)
                {
                    case "up":
                        currRow--;
                        if (currRow < 0 )
                        {
                            currRow = n - 1;
                        }
                        if (matrix[currRow, currCol] == "B")
                        {
                            currRow--;

                            if (currRow < 0)
                            {
                                currRow = n - 1;
                            }

                        }
                        if (matrix[currRow, currCol] == "T")
                        {
                            currRow++;
                            if (currRow > n - 1)
                            {
                                currRow = 0;
                            }

                        }


                        break;
                    case "down":

                        currRow++;
                        if (currRow > n - 1)
                        {
                            currRow = 0;
                        }
                        if (matrix[currRow, currCol] == "B")
                        {
                            currRow++;

                            if (currRow > n - 1)
                            {
                                currRow = 0;
                            }

                        }
                        if (matrix[currRow, currCol] == "T")
                        {
                            currRow--;
                            if (currRow < 0)
                            {
                                currRow = n - 1;
                            }


                        }

                        break;
                    case "left":

                        currCol--;
                        if ( currCol < 0 )
                        {
                            currCol = n - 1;
                        }
                        if (matrix[currRow, currCol] == "B")
                        {
                            currCol--;

                            if (currCol < 0)
                            {
                                currCol = n - 1;
                            }

                        }
                        if (matrix[currRow, currCol] == "T")
                        {
                            currCol++;
                            if (currCol > n - 1)
                            {
                                currCol = 0;
                            }

                        }
                        break;
                    case "right":

                        currCol++;
                        if (currCol > n - 1)
                        {
                            currCol = 0;
                        }
                        if (matrix[currRow, currCol] == "B")
                        {
                            currCol++;
                            if (currCol > n - 1)
                            {
                                currCol = 0;
                            }


                        }
                        if (matrix[currRow, currCol] == "T")
                        {
                            currCol--;
                            if (currCol < 0)
                            {
                                currCol = n - 1;
                            }

                        }

                        break;
                }


                if (matrix[currRow,currCol] == "F")
                {
                    matrix[currRow, currCol] = "f";
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    break;
                }
            }

            if (matrix[currRow, currCol] != "F" && matrix[currRow, currCol] != "f")
            {
                matrix[currRow, currCol] = "f";
                Console.WriteLine("Player lost!");
                PrintMatrix(matrix);
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
}
