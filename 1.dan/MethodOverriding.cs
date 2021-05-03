using System;

namespace oop
{
	public class Animal
	{
		public virtual void Eat()
		{
            Console.WriteLine("Eating...");
		}
	}
	public class Lion: Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Eating meat...");
        }
    }
	public class Zebra: Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Eating grass...");
        }
    }
    public class TestOverriding
    {
        public static void Main()
        {
            Lion l = new Lion();
            l.eat();
              
            Zebra z = new Zebra();
            z.eat();
        }
    }
}
