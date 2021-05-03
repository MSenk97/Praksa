using System;

namespace oop
{ 
	public class Student
	{
		public float payment = 100;
	}
	public class RedovanStudent: Student
	{
		public float bonus = 0;
	}
	public class IzvanredanStudent : Student
    {
		public float bonus = 6000;
    }
	class TestInheritance
    {
		public static void Main(string[] args)
        {
			RedovanStudent p1 = new RedovanStudent();
			IzvanredanStudent pm1 = new IzvanredanStudent();

			Console.WriteLine("Payment: " + p1.payment);
			Console.WriteLine("Bonus: " + p1.bonus);

			Console.WriteLine("Payment: " + pm1.payment);
			Console.WriteLine("Bonus: " + pm1.bonus);
		}
    }
}