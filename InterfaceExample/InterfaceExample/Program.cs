using System;
using System.Linq;
using System.Collections.Generic;

namespace InterfaceExample
{
    interface ISpeak
    {
        void Speak();
    }

    class Cat : ISpeak
    {
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("Meeaw");
        }
    }

    class Dog : ISpeak
    {
        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine("Bark");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var cat = new Cat();
            var dog = new Dog();

            List<ISpeak> animalsThatSpeaks = new List<ISpeak>();
            animalsThatSpeaks.Add(cat);
            animalsThatSpeaks.Add(dog);
            foreach (var animalThatSpeaks in animalsThatSpeaks)
            {
                animalThatSpeaks.Speak();
            }
        }
    }
}
