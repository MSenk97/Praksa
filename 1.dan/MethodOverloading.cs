using System;

namespace oop
{
	public class BasicCalc
	{

		public static float Summation(float x, float y)
		{
			return x + y;
		}

		public static float Summation(float x, float y, float z)
		{
			return x + y + z;
		}
		
		public static void Main(string[] args)
		{
			Console.WriteLine(BasicCalc.Summation(12.1f, 23.5f));
			Console.WriteLine(BasicCalc.Summation(12.1f, 23.5f, 34.9f));
		}
	}
}
