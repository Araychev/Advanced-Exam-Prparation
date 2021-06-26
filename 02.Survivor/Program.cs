using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] matrix = new string[rows][];

            int currRow = 0;
            int currCol = 0;
            int myTokens = 0;
            int oponentTokens = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split();
                matrix[row] = new string[rowData.Length];
                for (int col = 0; col < rowData.Length; col++)
                {
                    matrix[row][col] = rowData[col];

                }
            }


            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Gong")
                {
                    break;
                }

                string[] input = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
                if (command == "Find")
                {
                    currRow = int.Parse(input[1]);
                    currCol = int.Parse(input[2]);
                    if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                    {
                        if (matrix[currRow][currCol] == "T")
                        {
                            myTokens++;
                            matrix[currRow][currCol] = "-";
                        }

                    }

                }
                else
                {
                    currRow = int.Parse(input[1]);
                    currCol = int.Parse(input[2]);
                    string directions = input[3];


                    if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                    {
                        if (matrix[currRow][currCol] == "T")
                        {
                            oponentTokens++;
                            matrix[currRow][currCol] = "-";
                            switch (directions)
                            {
                                case "up":
                                    for (int i = 0; i < 3; i++)
                                    {
                                        currRow--;
                                        if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                                        {
                                            if (matrix[currRow][currCol] == "T")
                                            {
                                                oponentTokens++;
                                                matrix[currRow][currCol] = "-";
                                            }

                                        }
                                    }
                                    break;
                                case "down":
                                    for (int i = 0; i < 3; i++)
                                    {
                                        currRow++;
                                        if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                                        {
                                            if (matrix[currRow][currCol] == "T")
                                            {
                                                oponentTokens++;
                                                matrix[currRow][currCol] = "-";
                                            }

                                        }
                                    }

                                    break;
                                case "left":
                                    for (int i = 0; i < 3; i++)
                                    {
                                        currCol--;
                                        if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                                        {
                                            if (matrix[currRow][currCol] == "T")
                                            {
                                                oponentTokens++;
                                                matrix[currRow][currCol] = "-";
                                            }

                                        }
                                    }

                                    break;
                                case "right":
                                    for (int i = 0; i < 3; i++)
                                    {
                                        currCol++;
                                        if (currRow >= 0 && currRow < rows && currCol >= 0 && currCol < matrix[currRow].Length)
                                        {
                                            if (matrix[currRow][currCol] == "T")
                                            {
                                                oponentTokens++;
                                                matrix[currRow][currCol] = "-";

                                            }

                                        }
                                    }

                                    break;
                            }
                        }

                    }
                }
                    
            }

            PrintMatrix(matrix);
            Console.WriteLine($"Collected tokens: {myTokens}");
            Console.WriteLine($"Opponent's tokens: {oponentTokens}");

            static void PrintMatrix(string[][] matrix)
            {
                foreach (string[] row in matrix)
                {
                    Console.WriteLine(string.Join(" ", row));

                }
            }




        }
    }
}
