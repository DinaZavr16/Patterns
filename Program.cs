using System;

namespace AbstractFactory
{
    // AbstractProductA
    public abstract class Car
    {
        public abstract void Info();
        public void Interact(Engine engine)
        {
            Info();
            Console.WriteLine("Set Engine: ");
            engine.GetPower();
        }
        public void Interact(Wheels wheels)
        {
            Info();
            Console.WriteLine("Set wheels: ");
            wheels.Count();
        }
    }

    // ConcreteProductA1
    public class Ford : Car
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    //ConcreteProductA2
    public class Toyota : Car
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }

    // ConcreteProduct Mercedes
    public class Mercedes : Car
    {
        public override void Info()
        {
            Console.WriteLine("Mercedes");
        }
    }

    // AbstractProductB
    public abstract class Engine
    {
        public virtual void GetPower()
        {
        }
    }

    // ConcreteProductB1
    public class FordEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Ford Engine");
        }
    }

    //ConcreteProductB2
    public class ToyotaEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Toyota Engine");
        }
    }

    // ConcreteProduct Mercedes
    public class MercedesEngine : Engine
    {
        public override void GetPower()
        {
            Console.WriteLine("Mercedes Engine");
        }
    }

    // AbstractProduct Wheels
    public abstract class Wheels
    {
        public virtual void Count()
        {
        }
    }

    // ConcreteProductB1
    public class FordWheels : Wheels
    {
        public override void Count()
        {
            Console.WriteLine("Ford has 4 Wheels");
        }
    }

    //ConcreteProductB2
    public class ToyotaWheels : Wheels
    {
        public override void Count()
        {
            Console.WriteLine("Toyota has 4 Wheels");
        }
    }

    //ConcreteProduct Mercedes
    public class MercedesWheels : Wheels
    {
        public override void Count()
        {
            Console.WriteLine("Mercedes has 4 Wheels and + 1 spare");
        }
    }

    // AbstractFactory
    public interface ICarFactory
    {
        Car CreateCar();
        Engine CreateEngine();
        Wheels CreateWheels();
    }

    // ConcreteFactory1
    public class FordFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Ford();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new FordEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new FordWheels();
        }
    }

    // ConcreteFactory2
    public class ToyotaFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Toyota();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new ToyotaEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new ToyotaWheels();
        }
    }

    // ConcreteFactory Mercedes
    public class MercedesFactory : ICarFactory
    {
        // from CarFactory
        Car ICarFactory.CreateCar()
        {
            return new Mercedes();
        }

        Engine ICarFactory.CreateEngine()
        {
            return new MercedesEngine();
        }

        Wheels ICarFactory.CreateWheels()
        {
            return new MercedesWheels();
        }
    }

    public class ClientFactory
    {
        private Car car;
        private Engine engine;
        private Wheels wheels;
        public ClientFactory(ICarFactory factory)
        {
            //Абстрагування процесів інстанціювання
            car = factory.CreateCar();
            engine = factory.CreateEngine();
            wheels = factory.CreateWheels();
        }

        public void Run()
        {
            car.GetType();
            //Абстрагування варіантів використання
            car.Interact(engine);
            car.Interact(wheels);
        }
    }

    class AbstractFactoryApp
    {
        static void Main(string[] args)
        {
            ICarFactory carFactory = new ToyotaFactory();
            ClientFactory client1 = new ClientFactory(carFactory);

            client1.Run();

            carFactory = new FordFactory();
            ClientFactory client2 = new ClientFactory(carFactory);
            client2.Run();
            Console.WriteLine("");

            carFactory = new MercedesFactory();
            ClientFactory client3 = new ClientFactory(carFactory);
            client3.Run();
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}