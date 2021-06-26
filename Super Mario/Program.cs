using System;
using System.Collections.Generic;
using System.Linq;

namespace Super_Mario
{
    class Program
    {
        static void Main(string[] args)
        {
            int live = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            int currRow = 0;
            int currCol = 0;



            int[] peachIdx = new int[2];

            char[][] matrix = new char[rows][];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                matrix[row] = new char[line.Length];
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row][col] = line[col];
                    if (matrix[row][col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                    }

                }
            }

            matrix[currRow][currCol] = '-';
            bool missionAcomplished = false;

            while (true)
            {

                string[] cmd = Console.ReadLine().Split();

                string marioMove = cmd[0];

                int enemyRow = int.Parse(cmd[1]);
                int enemyCol = int.Parse(cmd[2]);
                matrix[enemyRow][enemyCol] = 'B';
                live--;

                switch (marioMove)
                {
                    case "W":
                        if (currRow - 1 < 0)
                        {
                            continue;
                        }
                        matrix[currRow][currCol] = '-';

                        currRow--;
                        break;

                    case "S":
                        if (currRow + 1 > rows)
                        {
                            continue;
                        }
                        matrix[currRow][currCol] = '-';

                        currRow++;
                        break;

                    case "A":
                        if (currCol - 1 < 0)
                        {
                            continue;
                        }
                        matrix[currRow][currCol] = '-';

                        currCol--;

                        break;

                    case "D":
                        if (currCol + 1 >= matrix[currCol].Length)
                        {
                            continue;
                        }
                        matrix[currRow][currCol] = '-';

                        currCol++;

                        break;
                }
                if (live <= 0)
                {
                    matrix[currRow][currCol] = 'X';
                    break;
                }

                if (matrix[currRow][currCol] == 'B')
                {
                    live -= 2;
                    if (live <= 0)
                    {
                        matrix[currRow][currCol] = 'X';
                        break;
                    }
                }
                else if (matrix[currRow][currCol] == 'P')
                {
                    missionAcomplished = true;
                    matrix[currRow][currCol] = '-';
                    break;
                }


            }

            if (missionAcomplished)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {live}");
            }
            else
            {
                Console.WriteLine($"Mario died at {currRow};{currCol}.");
            }

            PrintMatrix(matrix);
        }


        static void PrintMatrix(char[][] matrix)
        {
            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("", row));

            }
        }




    }
}
