using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var scraf = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            var sets = new Queue<int>();


            while (scraf.Count > 0 && hats.Count > 0)
            {
                if (hats.Peek() > scraf.Peek())
                {
                    sets.Enqueue(hats.Pop() + scraf.Dequeue());
                }
                else if (hats.Peek() < scraf.Peek())
                {
                    hats.Pop();
                    
                }
                else if(hats.Peek() == scraf.Peek())
                {
                    scraf.Dequeue();
                    hats.Push(hats.Pop() + 1);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            foreach (var item in sets)
            {
                Console.Write(item + " ");
            }
        }
    }
}
