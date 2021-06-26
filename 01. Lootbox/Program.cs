using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> first = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> second = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));


            int value = 0;

            while (true)
            {
                if (first.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (second.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }


                if ((first.Peek() + second.Peek()) % 2 == 0)
                {
                    value += first.Peek() + second.Peek();
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    first.Enqueue(second.Pop());
                }


            }


            if (value >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {value}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {value}");
            }
        
        }
    }
}
