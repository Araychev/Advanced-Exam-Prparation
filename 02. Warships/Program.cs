using System;
using System.Linq;

namespace _02._Warships
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[,] field = new string[size, size];
            string[] attackCmds = Console.ReadLine()
                .Split(",");


            for (int row = 0; row < field.GetLength(0); row++)
            {
                var fieldRow = Console.ReadLine().Split();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = fieldRow[col];
                }
            }

            for (int i = 0; i < attackCmds.Length; i++)
            {
                if (i % 2 != 0)
                {

                }
            }
        }
    }
}
