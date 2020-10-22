using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            List<int> sumed = new List<int>();
            int currentSum = 0;

            

            while (firstBox.Count()>0 && secondBox.Count()>0)
            {
                currentSum = firstBox.Peek() + secondBox.Peek();

                if (currentSum % 2 == 0)
                {
                    sumed.Add(currentSum);
                    firstBox.Dequeue();
                    secondBox.Pop();
                    currentSum = 0;
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                    currentSum = 0;
                }
            }

            if (firstBox.Count() == 0)  
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumed.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumed.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumed.Sum()}");
            }
        }
    }
}
