using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());

            List<int> plates = new List<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> warrior = new Stack<int>();
            int count = 0;
            while (count < waves)
            {
                count++;

                warrior = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
                int rotet = warrior.Count;
                for (int j = 0; j < rotet; j++)
                {
                    if (plates.Count > 0 && plates[0] >= warrior.Peek())
                    {
                        plates[0] -= warrior.Pop();
                        if (plates[0] <= 0)
                        {
                            plates.Remove(plates[0]);
                        }

                    }
                    else if (warrior.Count > 0)
                    {
                        if (plates.Count > 0)
                        {
                            int currHealth = warrior.Peek();
                            warrior.Pop();
                            warrior.Push(currHealth - plates[0]);
                            plates.Remove(plates[0]);

                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (count == 3)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }
                if (plates.Count == 0)
                {
                    break;
                }

            }

            if (plates.Count > 0)
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", warrior)}");

            }
        }
    }
}
