using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter
{
   /*
    * Animal Shelter: An animal shelter, which holds only dogs and cats, operates on a strictly"first in, first out" basis. 
    * People must adopt either the "oldest" (based on arrival time) of all animals at the shelter, 
    * or they can select whether they would prefer a dog or a cat (and will receive the oldest animal of that type). 
    * They cannot select which specific animal they would like. Create the data structures to maintain this system 
    * and implement operations such as enqueue, dequeueAny, dequeueDog, and dequeueCat. 
    * You may use the built-in Linkedlist data structure.
    */
    class Shelter
    {
        Dictionary<AnimalType, Stack<(DateTimeOffset, Animal)>> Stacks = new Dictionary<AnimalType, Stack<(DateTimeOffset, Animal)>>();

        public void Enqueue(Animal item)
        {
            var ts = DateTimeOffset.Now;
            if (Stacks.TryGetValue(item.Type, out var stack))
                stack.Push((ts, item));
            else
                Stacks.Add(item.Type, new Stack<(DateTimeOffset, Animal)>(new[] { (ts, item) }));

        }

        public Animal DequeueAny()
        {
            return DequeueAnimal(null);
        }

        public Animal DequeueDog()
        {
            return DequeueAnimal(AnimalType.DOG);
        }

        public Animal DequeueCat()
        {
            return DequeueAnimal(AnimalType.CAT);
        }

        private Animal DequeueAnimal(AnimalType? type)
        {
            Stack<(DateTimeOffset, Animal)> oldestStack;

            if (type == null)
            {
                if (Stacks.Count == 0)
                    throw new InvalidOperationException("Animal shelter is empty");

                //Stack with min date
                oldestStack = Stacks.Values
                   .OrderBy(x => x.Peek().Item1)
                   .First();
            }
            else if (!Stacks.TryGetValue(type.Value, out oldestStack))
            {
                throw new InvalidOperationException($"There are not animals type of {type} in this shelter");
            }

            var oldestanimal = oldestStack.Pop().Item2;

            if (oldestStack.Count == 0)
                Stacks.Remove(oldestanimal.Type);

            return oldestanimal;
        }

        public string PrintStacks()
        {
            var sb = new StringBuilder("....\n");
            if (Stacks.Count == 0)
            {
                sb.AppendLine("Empty");
            }
            else
            {
                foreach (var stack in Stacks)
                {
                    var value = stack.Value.Reverse().Select(x => x.Item2.Type);
                    sb.AppendLine(string.Join(",", value));
                }
            }
            sb.AppendLine("....");
            return sb.ToString();
        }
    }
}
