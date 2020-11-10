using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Game Create();
        //public abstract Product FactoryMethod(int type);
    }

    public class IndiGameDeveloper : Developer
    {
        public IndiGameDeveloper(string n) : base(n)
        { }

        public override Game Create()
        {
            return new IndiGame();
        }
    }

    class HorrorGameDeveloper : Developer
    {
        public HorrorGameDeveloper(string n) : base(n)
        { }

        public override Game Create()
        {
            return new HorrorGame();
        }
    }

    public abstract class Game { } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class IndiGame : Game
    {
        public IndiGame()
        {
            Console.WriteLine("You've got an indi game");
        }
    }

    public class HorrorGame : Game
    {
        public HorrorGame()
        {
            Console.WriteLine("You've got a horror game! Be careful");
        }
    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Developer dev = new IndiGameDeveloper("Grassman's inc.");
            Game game = dev.Create();

            dev = new HorrorGameDeveloper("Private developer");
            Game game1 = dev.Create();

        }
    }
}

