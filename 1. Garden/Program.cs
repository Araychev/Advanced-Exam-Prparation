using System;
using System.Linq;

namespace _1._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[,] garden = new int[size[0], size[1]];


            while (true)
            {
                string tokens = Console.ReadLine();
                if (tokens == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] command = tokens.Split().Select(int.Parse).ToArray();
                int row = command[0];
                int col = command[1];

                if (row < 0 || row > garden.GetLength(0) && col < 0 || col > garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                for (int i = 0; i < garden.GetLength(0); i++)
                {
                    garden[row, i]++;
                }
                for (int j = 0; j < garden.GetLength(1); j++)
                {
                    garden[j,col]++;
                }
                garden[row, col]--;
            }


            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write("{0} ", garden[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
