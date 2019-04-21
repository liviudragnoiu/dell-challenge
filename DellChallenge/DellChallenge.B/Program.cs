using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)

            Species species = new Human();
            species.GetSpecies();

            species = new Bird();
            species.GetSpecies();

            species = new Fish();
            species.GetSpecies();

            Console.ReadKey();

        }
    }

    public class Species
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine($"Echo who am I?");
        }
    }

    public interface ISpecies
    {
        void Eat();
    }

    public interface IHumanSpecies : ISpecies, IFishSpecies
    {
        void Drink();
    }

    public interface IFishSpecies : ISpecies
    {
        void Swim();
    }

    public interface IBirdSpecies : ISpecies
    {
        void Fly();
    }

    public class Human : Species, IHumanSpecies
    {
        public void Drink()
        {
            Console.WriteLine($"I'm a {nameof(Human)} and I drink.");
        }

        public void Eat()
        {
            Console.WriteLine($"I'm a {nameof(Human)} and I eat.");
        }

        public void Swim()
        {
            Console.WriteLine($"I'm a {nameof(Human)} and I swim.");
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I'm a {nameof(Human)}");
        }
    }

    public class Bird : Species, IBirdSpecies
    {
        public void Eat()
        {
            Console.WriteLine($"I'm a {nameof(Bird)} and I eat.");
        }

        public void Fly()
        {
            Console.WriteLine($"I'm a {nameof(Bird)} and I fly.");
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I'm a {nameof(Bird)}");
        }
    }

    public class Fish : Species, IFishSpecies
    {
        public void Eat()
        {
            Console.WriteLine($"I'm a {nameof(Fish)} and I eat.");
        }

        public void Swim()
        {
            Console.WriteLine($"I'm a {nameof(Fish)} and I swim.");
        }

        public override void GetSpecies()
        {
            Console.WriteLine($"I'm a {nameof(Fish)}");
        }
    }
}

