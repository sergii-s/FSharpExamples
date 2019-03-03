using System;
using System.Threading.Tasks;

namespace ExamplesCSharp.Exemple5
{
	public class User
	{
		public readonly int Age;
		public readonly string Name;

		public User(int age, string name)
		{
			Age = age;
			Name = name;
		}
	}

	public class Exemple5
	{
		public static void Handle1(User user)
		{
			if (user.Age < 5)
			{
				Console.WriteLine("User is infant");
			}
			else if (user.Age < 18)
			{
				Console.WriteLine("User is adolescent");
			}
			else if (user.Age < 31)
			{
				Console.WriteLine("User is young");
			}
			else
			{
				Console.WriteLine("User is old");
			}
		}

		public static void Handle2(User user)
		{
			if (user.Age < 5)
			{
				// ... 
			}
			else if (user.Age < 18)
			{
				// ... 
			}
			else if (user.Age < 31)
			{
				// ... 
			}
			else
			{
				// ... 
			}
		}
	}
}
