using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int countWreaths = 0;
            int extraFlower = 0;
            while (lilies.Count > 0 && roses.Count > 0)
            {
                int sum = lilies.Peek() + roses.Peek();
                if (sum == 15)
                {
                    lilies.Pop();
                    roses.Dequeue();
                    countWreaths++;
                }
                if (sum > 15)
                {
                    lilies.Push(lilies.Pop() - 2);
                }
                if (sum < 15)
                {
                    extraFlower += sum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            countWreaths += extraFlower / 15;

            if (countWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countWreaths} wreaths more!");
            }
        }
    }
}
