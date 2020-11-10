using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            OrnamentedChristmasTree myTree = new OrnamentedChristmasTree();
            ChristmasTreeWithLight lightingCT = new ChristmasTreeWithLight("blue");
            ChristmasTreeWithGarland topperedCT = new ChristmasTreeWithGarland("yellow");

            lightingCT.SetTree(myTree);
            topperedCT.SetTree(lightingCT);

            topperedCT.Decorate();
        }
    }
    abstract class ChristmasTree
    {
        public abstract void Decorate();
    }

    class OrnamentedChristmasTree : ChristmasTree
    {
        public override void Decorate()
        {
            Console.WriteLine("Your tree has ornament");
        }
    }

    abstract class ChristmasTreeDecorator : ChristmasTree
    {
        protected ChristmasTree tree;

        public void SetTree(ChristmasTree _tree)
        {
            tree = _tree;
        }

        public override void Decorate()
        {
            if (tree != null)
            {
                tree.Decorate();
            }
        }
    }

    class ChristmasTreeWithGarland : ChristmasTreeDecorator
    {
        public string Garland { get; set; }
        public ChristmasTreeWithGarland(string _garland)
        {
            Garland = _garland;
        }
        public override void Decorate()
        {
            base.Decorate();

            Console.WriteLine($"Your tree now has {Garland} garland");
        }
    }

    class ChristmasTreeWithLight : ChristmasTreeDecorator
    {
        public string Lights { get; private set; }

        public ChristmasTreeWithLight(string _lights)
        {
            Lights = _lights;
        }

        public override void Decorate()
        {
            base.Decorate();

            Console.WriteLine($"Now you have {Lights} lights");
        }
    }
}