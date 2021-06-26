using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> ingridientValue = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));


            int chocolateCake = 0;
            int dippingSouce = 0;
            int greenSalad = 0;
            int lobster = 0;


            while (ingridientValue.Count > 0 && freshness.Count > 0)
            {
                if (ingridientValue.Peek() == 0)
                {
                    ingridientValue.Dequeue();
                    continue;
                }

                int result = ingridientValue.Peek() * freshness.Peek();

                switch (result)
                {
                    case 150:
                        dippingSouce++;
                        ingridientValue.Dequeue();
                        freshness.Pop();
                        break;
                    case 250:
                        greenSalad++;
                        ingridientValue.Dequeue();
                        freshness.Pop();

                        break;
                    case 300:
                        chocolateCake++;
                        ingridientValue.Dequeue();
                        freshness.Pop();

                        break;
                    case 400:
                        lobster++;
                        ingridientValue.Dequeue();
                        freshness.Pop();

                        break;
                }

                if (result != 150 && result != 250 && result != 300 && result != 400)
                {
                    freshness.Pop();
                    ingridientValue.Enqueue(ingridientValue.Dequeue() + 5);
                }

            }


            if (chocolateCake > 0 && dippingSouce > 0 && greenSalad > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingridientValue.Count > 0)
            {
                int ingridientsSum = 0;
                if (ingridientValue.Count == 1)
                {
                    ingridientsSum += ingridientValue.Dequeue();
                }
                else
                {
                    for (int i = 0; i <= ingridientValue.Count+1; i++)
                    {
                        ingridientsSum += ingridientValue.Dequeue();
                    }

                }

                Console.WriteLine($"Ingredients left: {ingridientsSum}");
            }

            if (chocolateCake > 0)
            {
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }
            if (dippingSouce > 0)
            {
                Console.WriteLine($"# Dipping sauce --> {dippingSouce}");
            }
            if (greenSalad > 0)
            {
                Console.WriteLine($"# Green salad --> {greenSalad}");
            }
            if (lobster > 0)
            {
                Console.WriteLine($"# Lobster --> {lobster}");
            }




        }
    }
}
