using System;

namespace AnimalShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            string enqueue = "Enqueue", dequeueAny = "DequeueAny", dequeueCat = "DequeueCat", dequeueDog = "DequeueDog";
            var cat = new Animal(AnimalType.CAT);
            var dog = new Animal(AnimalType.DOG);
            var algo = new Shelter();

            var test = new (string, Animal)[]
            {
                (enqueue, dog),
                (enqueue, dog),
                (enqueue, cat),
                (enqueue, cat),
                (dequeueAny, null),
                (dequeueCat,null),
                (enqueue, cat),
                (dequeueAny, null),
                (dequeueAny, null),
                (dequeueAny, null),
            };

            foreach (var item in test)
            {
                if (item.Item1 == enqueue)
                {
                    Console.WriteLine($"{item.Item1}({item.Item2.Type})");
                    algo.Enqueue(item.Item2);
                }
                else if (item.Item1 == dequeueAny)
                    Console.WriteLine($"{item.Item1}() = {algo.DequeueAny().Type}");
                else if (item.Item1 == dequeueDog)
                    Console.WriteLine($"{item.Item1}() = {algo.DequeueDog().Type}");
                else if (item.Item1 == dequeueCat)
                    Console.WriteLine($"{item.Item1}() = {algo.DequeueCat().Type}");

                Console.WriteLine(algo.PrintStacks());
            }
        }
    }
}
