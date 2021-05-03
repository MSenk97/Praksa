using System;

namespace oop
{ 

	abstract class AbstractClass 
	{
		public int Summation(int x, int y)
        {
			return x + y;
        }

		public abstract int Multiplication(int x, int y);
	}

	class Derived : AbstractClass
    {
        public override int Multiplication(int x, int y)
        {
            return x * y;
        }
    }
    class geek
    {
        public static void Main()
        {
            //instanca derivirane klase
            Derived d = new Derived();
            Console.WriteLine("Summation :" + d.Summation(4,6));
            Console.WriteLine("Multiplication:" + d.Multiplication(4,6));
        }
    }
}